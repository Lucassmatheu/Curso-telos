const prompt = require('prompt-sync')({ sigint: true });

const produtos = [
    { codigo: "001", nome: "Computador Desktop Intel Core i5", preco: 3199.00 },
    { codigo: "002", nome: "Laptop Ultrabook Intel Core i7", preco: 4799.00 },
    { codigo: "003", nome: "Monitor LED 24 polegadas Full HD", preco: 799.90 },
    { codigo: "004", nome: "Teclado Mec�nico Gamer RGB", preco: 299.00 },
    { codigo: "005", nome: "Mouse �ptico Sem Fio", preco: 79.90 }
];

let listaDeLancamentos = [];

function mostrarMenu() {
    console.log("\nBem-vindo ao TelosNF!");
    console.log("Selecione uma op��o:");
    console.log("(1) Visualizar produtos cadastrados");
    console.log("(2) Lan�ar venda de produto");
    console.log("(3) Imprimir nota fiscal");
    console.log("(4) Iniciar uma nova venda");
    console.log("(5) Sair");
}

function visualizarProdutos() {
    console.log("\nProdutos cadastrados:");
    produtos.forEach(produto => {
        console.log(`${produto.codigo} - ${produto.nome} - R$ ${produto.preco.toFixed(2)}`);
    });
}

function lancarVenda() {
    visualizarProdutos();
    const codigo = prompt("Digite o c�digo do produto que deseja adicionar: ");
    const produto = produtos.find(p => p.codigo === codigo);

    if (produto) {
        const quantidade = parseInt(prompt("Digite a quantidade de itens que est� sendo vendida: "), 10);
        listaDeLancamentos.push({ ...produto, quantidade });
        console.log("Produto adicionado com sucesso!");
    } else {
        console.log("Produto n�o encontrado.");
    }
}

function iniciarNovaVenda() {
    listaDeLancamentos = [];
    console.log("Nova venda iniciada!");
}

function imprimirNotaFiscal() {
    if (listaDeLancamentos.length === 0) {
        console.log("Nenhum produto foi adicionado para venda.");
        return;
    }

    console.log("\n ___________________________________________________|");
    console.log(" |  NOTA FISCAL                                       |");
    console.log(" |                                                    |");
    console.log(" | Empresa: T�los NF                                  |");
    console.log(" | CNPJ: 12.345.678/0001-90                           |");
    console.log(" | Endere�o: Rua das Flores, 123                      |");
    console.log(" | Cidade: Cidade Exemplo                             |");
    console.log(` | Data: ${new Date().toLocaleDateString()}           |`);
    console.log(" | N�mero: 123                                        |");
    console.log(" |                                                    |");
    console.log(" |----------------------------------------------------|");
    console.log(" | Qtd | Produto                  | Pre�o (R$)        |");
    console.log(" |----------------------------------------------------|");

    let total = 0;
    listaDeLancamentos.forEach(lancamento => {
        const nomeProduto = lancamento.nome.length > 33 ? lancamento.nome.slice(0, 30) + '...' : lancamento.nome.padEnd(33);
        console.log(` | ${lancamento.quantidade}   | ${nomeProduto} | ${lancamento.preco.toFixed(2).padStart(10)} |`);
        total += lancamento.preco * lancamento.quantidade;
    });

    console.log(" |---------------------------------------------|");
    console.log(` | TOTAL:                                | R$ ${total.toFixed(2).padStart(10)} |`);
    console.log(" |---------------------------------------------|");
    console.log(" Observa��o: este � apenas um modelo. Sintam-se livres para");
    console.log(" testar outros modelos, desde que todas as informa��es");
    console.log(" estejam contidas.");
}

function main() {
    let opcao;
    while (true) {
        mostrarMenu();
        opcao = prompt("Digite a op��o desejada: ");

        if (opcao === "1") {
            visualizarProdutos();
        } else if (opcao === "2") {
            lancarVenda();
        } else if (opcao === "3") {
            imprimirNotaFiscal();
        } else if (opcao === "4") {
            iniciarNovaVenda();
        } else if (opcao === "5") {
            console.log("Saindo do sistema...");
            break;
        } else {
            console.log("Op��o inv�lida. Tente novamente.");
        }
    }
}

main();
