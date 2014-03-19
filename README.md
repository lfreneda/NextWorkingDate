NextWorkingDate
===============

Hoje é um dia útil? Qual é o próximo dia útil? Pequena lógica para determinar o próximo (ou se hoje é) dia útil.

### Pra que isso?

Em um projeto que trabalhei precisavamos gerar boletos, e a data de vencimento do boleto devia ser um dia útil.

A Páscoa, Corpus Christi e o nosso Carnaval acontecem em datas diferentes a cada ano, levamos isso em conta nessa pequena library. 


### Como usar?

```C#
      var date = DateTime.Now; //or whatever date you want to :P
      
      var nextWorkingDate = new NextWorkingDate(new ConfigurationHolidayProvider(), new BrazilianNonFixedHolidays(DateTime.Now.Year));
      
      var workingDate = nextWorkingDate.GetNext(date);
```

### IHolidayProvider

Caso queria alterar de onde buscar feriados, basta criar uma nova implementação da IHolidayProvider, por exemplo, você pode querer buscar isso do banco de dados

Assumindo que você tem a seguinte estrutura:

```sql
HolidayId   Description                                        Year Month Day
----------- -------------------------------------------------- ---- ----- ----
9           Confraternização Universal                         NULL 1     1
10          Tiradentes                                         NULL 4     21
11          Dia do Trabalho                                    NULL 5     1
12          Independência do Brasil                            NULL 9     7
13          Nossa Senhora Aparecida                            NULL 10    12
14          Finados                                            NULL 11    2
15          Proclamação da República                           NULL 11    15
16          Natal                                              NULL 12    25
```

Você pode ter um provider mais ou menos assim:

```C#
    public class DataBaseHolidayProvider : IHolidayProvider
    {
        private int ExecuteScalar(string query, DateTime date)
        {
            //Implementation goes here..
        }

        public bool IsHoliday(DateTime date)
        {
            var count = ExecuteScalar(@"SELECT COUNT(0) FROM tbHoliday 
                              					  WHERE ([Day] = @day AND [Month] = @month AND [Year] IS NULL) 
                              						 OR ([Day] = @day AND [Month] = @month AND [Year] = @year)", date);
            return count > 1;
        }
    }
```
