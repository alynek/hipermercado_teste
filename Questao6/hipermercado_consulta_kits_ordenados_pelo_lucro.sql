--tabela que busca os produtos mais bem avaliados
select 
p.Nome,
p.DataValidade,
pm.Satisfacao,
ee.Preco,
ee.Custo,
e.Quantidade
into #ProdutoLimpezaBemAvaliado
from ProdutoLimpeza p
inner join ElementoEstoque ee
on(p.Id_ElementoEstoque = ee.Id)
inner join Estoque e
on(e.Id_ElementoEstoque = ee.Id)
inner join PesquisaMercado pm
on(pm.id_produtolimpeza = p.Id)
where pm.Satisfacao >= 70

--tabela que busca os alimentos próximos do vencimento
select 
a.Nome,
a.DataValidade,
ee.Preco,
ee.Custo,
e.Quantidade
into #AlimentoProximoDoVencimento
from Alimento a
inner join ElementoEstoque ee
on(a.Id_ElementoEstoque = ee.Id)
inner join Estoque e
on(e.Id_ElementoEstoque = ee.Id)
where DATEDIFF(day, getdate(), a.DataValidade) < 5

--tabela que monta os kits
select 
plba.Nome as NomeProdutoLimpeza,
apdv.Nome as NomeAlimento,
cast((plba.Preco + apdv.Preco) * 0.85 as decimal(10,2)) as PrecoKit,
cast(((plba.Preco + apdv.Preco) * 0.85) - (plba.Custo + apdv.Custo) as decimal (10,2)) as LucroKit,
case 
	when plba.DataValidade < apdv.DataValidade then plba.DataValidade
	else apdv.DataValidade 
	end as DataDeValidadeDoKit,
case
	when plba.Quantidade < apdv.Quantidade then plba.Quantidade
	else apdv.Quantidade
	end as QuantidadeMaximaKits
from #ProdutoLimpezaBemAvaliado plba
join #AlimentoProximoDoVencimento apdv
on 1 =1
order by LucroKit


drop table #ProdutoLimpezaBemAvaliado
drop table #AlimentoProximoDoVencimento