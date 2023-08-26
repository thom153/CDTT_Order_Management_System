select distinct m.MainID, m.aDate, m.aTime from tblMain m
                        inner join tblDetails d on m.MainID = d.MainID
                        where m.aDate between '2023-08-10' and '2023-08-26'