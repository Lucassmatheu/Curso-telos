function obterDiaDaSemana(dia)
{
    let nomeDodia;
    switch(dia)
    {
       case 1:
            nomeDoDia = "Domingo";
            break;
        case 2:
            nomeDoDia = "Segunda-feira";
            break;
        case 3:
            nomeDoDia = "Ter�a-feira";
            break;
        case 4:
            nomeDoDia = "Quarta-feira";
            break;
        case 5:
            nomeDoDia = "Quinta-feira";
            break;
        case 6:
            nomeDoDia = "Sexta-feira";
            break;
        case 7:
            nomeDoDia = "S�bado";
            break;
        default:
            nomeDoDia = "Dia inv�lido";
    }
    return nomeDoDia;
}
console.log(obterDiaDaSemana(1)); // Domingo
console.log(obterDiaDaSemana(4)); // Quarta-feira
console.log(obterDiaDaSemana(8)); // Dia inv�lido

