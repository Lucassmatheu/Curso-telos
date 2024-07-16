const prompt = require('prompt-sync')({ sigint: true });
function calculadora()
{
    const operacao = prompt("Escolha uma operação: \n1 - Adição \n2 - Subtração \n3 - Multiplicação \n4 - Divisão \n5 - Potência \n6 - Raiz Quadrada");

    let numero1, numero2, resutado;

      switch (operacao) {
        case '1':
            numero1 = parseFloat(prompt("Digite o primeiro número:"));
            numero2 = parseFloat(prompt("Digite o segundo número:"));
            resultado = numero1 + numero2;
            break;
        case '2':
            numero1 = parseFloat(prompt("Digite o primeiro número:"));
            numero2 = parseFloat(prompt("Digite o segundo número:"));
            resultado = numero1 - numero2;
            break;
        case '3':
            numero1 = parseFloat(prompt("Digite o primeiro número:"));
            numero2 = parseFloat(prompt("Digite o segundo número:"));
            resultado = numero1 * numero2;
            break;
        case '4':
            numero1 = parseFloat(prompt("Digite o primeiro número:"));
            numero2 = parseFloat(prompt("Digite o segundo número:"));
            resultado = numero1 / numero2;
            break;
        case '5':
            numero1 = parseFloat(prompt("Digite a base:"));
            numero2 = parseFloat(prompt("Digite o expoente:"));
            resultado = Math.pow(numero1, numero2);
            break;
        case '6':
            numero1 = parseFloat(prompt("Digite o número:"));
            resultado = Math.sqrt(numero1);
            break;
        default:
            console.log("Operação inválida");
            return;
    }

    console.log(`O resultado é: ${resultado}`);
}
calculadora();