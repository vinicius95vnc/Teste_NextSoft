use Teste_NextSoft

select Condominio.nome, count(condominio.nome) Pessoas_com_50_anos_ou_mais from Morador, familia, Condominio 
where Morador.Idade >= 50 and morador.Id_Familia = Familia.Id and familia.Id_Condominio = Condominio.Id group by Condominio.Nome