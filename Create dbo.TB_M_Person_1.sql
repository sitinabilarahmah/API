select * from TB_M_Person p
LEFT JOIN TB_M_Account a on
p.NIK = a.NIK
LEFT JOIN TB_T_Profiling pr on
a.NIK = pr.NIK
LEFT JOIN TB_M_Education e on
pr.Educationid = e.id
LEFT JOIN TB_M_University u on
e.Universityid = u.id

select * from TB_M_Person


