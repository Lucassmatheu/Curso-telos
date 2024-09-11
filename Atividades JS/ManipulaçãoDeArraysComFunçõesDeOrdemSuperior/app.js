// Função para filtrar pessoas maiores de idade e retornar os nomes
function maioresDeIdade(pessoas) {
    return pessoas.filter(pessoa => pessoa.idade >= 18).map(pessoa => pessoa.nome);
}

// Array de objetos representando pessoas
const pessoas = [
    { nome: "Lucas", idade: 25 },
    { nome: "Ana", idade: 17 },
    { nome: "Marcos", idade: 30 },
    { nome: "Joana", idade: 15 }
];

// Chamar a função e exibir os resultados no console
console.log(maioresDeIdade(pessoas)); // ["Lucas", "Marcos"]
