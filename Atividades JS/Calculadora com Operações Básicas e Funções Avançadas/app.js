const prompt = require('prompt-sync')({ sigint: true });
function calculadora()
{
    const operacao = prompt("Escolha uma opera��o: \n1 - Adi��o \n2 - Subtra��o \n3 - Multiplica��o \n4 - Divis�o \n5 - Pot�ncia \n6 - Raiz Quadrada");

    let numero1, numero2, resutado;

      switch (operacao) {
        case '1':
            numero1 = parseFloat(prompt("Digite o primeiro n�mero:"));
            numero2 = parseFloat(prompt("Digite o segundo n�mero:"));
            resultado = numero1 + numero2;
            break;
        case '2':
            numero1 = parseFloat(prompt("Digite o primeiro n�mero:"));
            numero2 = parseFloat(prompt("Digite o segundo n�mero:"));
            resultado = numero1 - numero2;
            break;
        case '3':
            numero1 = parseFloat(prompt("Digite o primeiro n�mero:"));
            numero2 = parseFloat(prompt("Digite o segundo n�mero:"));
            resultado = numero1 * numero2;
            break;
        case '4':
            numero1 = parseFloat(prompt("Digite o primeiro n�mero:"));
            numero2 = parseFloat(prompt("Digite o segundo n�mero:"));
            resultado = numero1 / numero2;
            break;
        case '5':
            numero1 = parseFloat(prompt("Digite a base:"));
            numero2 = parseFloat(prompt("Digite o expoente:"));
            resultado = Math.pow(numero1, numero2);
            break;
        case '6':
            numero1 = parseFloat(prompt("Digite o n�mero:"));
            resultado = Math.sqrt(numero1);
            break;
        default:
            console.log("Opera��o inv�lida");
            return;
    }

    console.log(`O resultado �: ${resultado}`);
}
calculadora();