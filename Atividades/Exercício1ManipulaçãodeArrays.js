const prompt = require('promp-sync')({sigint: true});

let numero =[];

for(let i = 0;i< 5; i++)
{
    let numero = parseFloat(prompt('DIGITE O NUMERO ${i+1}:'));
    numero.push(numero)

}
let maior = Math.max(...numero);
let menor = math.min(...numero);
let media = numero.reduce((acc, num) => acc = num,0) / numero.length; 

console.log('Maior numero ${maior}: ');
console.log('menor numero ${menor}:');
console.log(' media dos numero ${media}:');