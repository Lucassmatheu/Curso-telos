var item =
{
    valor: 20,
    decricao: "Camiseta azul simples",
    tamanho :"M",
    tipo:"camiseta",
    disponivel: true
}

var item02 ={
    
    valor: 11,
    decricao: "Camiseta azul simples",
    tamanho :"G",
    tipo:"camiseta",
    nome: "Camiseta vermelha", 
    disponivel: true
}
var disponivel =[item, item02];

disponivel.splice(1,1);


if(item.disponivel)
{
    item.disponivel = false;
    disponivel.push(item)
}

console.log(disponivel);