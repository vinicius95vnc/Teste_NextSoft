use Teste_NextSoft

select Morador.Nome as Morador, Familia.Nome as Familia, Condominio.nome as Condominio from Morador, familia, Condominio 
where morador.Id_Familia = Familia.Id and familia.Id_Condominio = Condominio.Id group by Morador.Nome, Familia.Nome, Condominio.Nome order by Morador.Nome