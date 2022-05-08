use Teste_NextSoft

select Condominio.Bairro as Bairro, AVG(Morador.Idade) as  Media_idade from Condominio, Familia, Morador 
where Morador.Id_Familia = Familia.Id and Familia.Id_Condominio = Condominio.Id group by Condominio.Bairro