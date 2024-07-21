// Dados de exemplo fornecidos pelo governo
const dados = `
[
    {"orgao":"MEC","data":"01/01/2024","valor":500.00,"status":"sucesso"},
    {"orgao":"Ministério da Saúde","data":"03/01/2024","valor":750.00,"status":"sucesso"},
    {"orgao":"MEC","data":"05/01/2024","valor":1000.00,"status":"falha","motivo":"falta de documentação"},
    {"orgao":"Ministério da Educação","data":"08/01/2024","valor":600.00,"status":"sucesso"},
    {"orgao":"Ministério da Saúde","data":"10/01/2024","valor":900.00,"status":"sucesso"},
    {"orgao":"Ministério da Educação","data":"12/01/2024","valor":300.00,"status":"falha","motivo":"dados inválidos"},
    {"orgao":"Ministério da Saúde","data":"15/01/2024","valor":1200.00,"status":"sucesso"},
    {"orgao":"MEC","data":"17/01/2024","valor":800.00,"status":"sucesso"},
    {"orgao":"Ministério da Educação","data":"20/01/2024","valor":400.00,"status":"sucesso"},
    {"orgao":"MEC","data":"22/01/2024","valor":1100.00,"status":"falha","motivo":"falta de verba"}
]
`;
// Parse dos dados
const repasses = JSON.parse(dados);

// História de Usuário 1: Exibir a quantidade total de repasses
const totalRepasses = repasses.length;
console.log(`\nTotal de repasses processados: ${totalRepasses}`);

// História de Usuário 2: Analisar transações por status
function analisarRepasses(repasses) {
  const sucesso = repasses.filter((rep) => rep.status === "sucesso");
  const falha = repasses.filter((rep) => rep.status === "falha");

  const resumoSucesso = {
    totalSucesso: sucesso.length,
    totalSucessoOrgao: {},
    valorTotalSucesso: sucesso.reduce((sum, rep) => sum + rep.valor, 0),
    valorTotalSucessoOrgao: {}
  };

  sucesso.forEach((rep) => {
    const orgao = rep.orgao;
    if (!resumoSucesso.totalSucessoOrgao[orgao]) {
      resumoSucesso.totalSucessoOrgao[orgao] = 0;
      resumoSucesso.valorTotalSucessoOrgao[orgao] = 0;
    }
    resumoSucesso.totalSucessoOrgao[orgao] += 1;
    resumoSucesso.valorTotalSucessoOrgao[orgao] += rep.valor;
  });

  const resumoFalha = {
    totalFalha: falha.length,
    totalFalhaOrgao: {},
    totalFalhaMotivo: {},
    valorTotalFalha: falha.reduce((sum, rep) => sum + rep.valor, 0),
    valorTotalFalhaOrgao: {},
    valorTotalFalhaMotivo: {}
  };

  falha.forEach((rep) => {
    const orgao = rep.orgao;
    const motivo = rep.motivo || "motivo desconhecido";
    if (!resumoFalha.totalFalhaOrgao[orgao]) {
      resumoFalha.totalFalhaOrgao[orgao] = 0;
      resumoFalha.valorTotalFalhaOrgao[orgao] = 0;
    }
    if (!resumoFalha.totalFalhaMotivo[motivo]) {
      resumoFalha.totalFalhaMotivo[motivo] = 0;
      resumoFalha.valorTotalFalhaMotivo[motivo] = 0;
    }
    resumoFalha.totalFalhaOrgao[orgao] += 1;
    resumoFalha.valorTotalFalhaOrgao[orgao] += rep.valor;
    resumoFalha.totalFalhaMotivo[motivo] += 1;
    resumoFalha.valorTotalFalhaMotivo[motivo] += rep.valor;
  });

  return { resumoSucesso, resumoFalha };
}

const { resumoSucesso, resumoFalha } = analisarRepasses(repasses);

// Exibir resumo dos repasses bem-sucedidos
console.log("\nResumo dos repasses bem-sucedidos:");
console.log(
  `\nQuantidade total de repasses bem-sucedidos: ${resumoSucesso.totalSucesso}`
);
console.log("\nQuantidade total de repasses bem-sucedidos por órgão:");
Object.keys(resumoSucesso.totalSucessoOrgao).forEach((orgao) => {
  console.log(`${orgao}: ${resumoSucesso.totalSucessoOrgao[orgao]}`);
});
console.log(`\nValor total de repasses bem-sucedidos: ${resumoSucesso.valorTotalSucesso}`
);
console.log("Valor total de repasses bem-sucedidos por órgão:");
Object.keys(resumoSucesso.valorTotalSucessoOrgao).forEach((orgao) => {
  console.log(`${orgao}: ${resumoSucesso.valorTotalSucessoOrgao[orgao]}`);
});

console.log("\nResumo dos repasses com falha:");
console.log(
  `\nQuantidade total de repasses com falha: ${resumoFalha.totalFalha}`
);
console.log("\nQuantidade total de repasses com falha por órgão:");
Object.keys(resumoFalha.totalFalhaOrgao).forEach((orgao) => {
  console.log(`${orgao}: ${resumoFalha.totalFalhaOrgao[orgao]}`);
});
console.log("Quantidade total de repasses com falha por motivo:");
Object.keys(resumoFalha.totalFalhaMotivo).forEach((motivo) => {
  console.log(`${motivo}: ${resumoFalha.totalFalhaMotivo[motivo]}`);
});
console.log(`\nValor total de repasses com falha: ${resumoFalha.valorTotalFalha}`);
console.log("\nValor total de repasses com falha por órgão:");
Object.keys(resumoFalha.valorTotalFalhaOrgao).forEach((orgao) => {
  console.log(`${orgao}: ${resumoFalha.valorTotalFalhaOrgao[orgao]}`);
});
console.log("\nValor total de repasses com falha por motivo:");
Object.keys(resumoFalha.valorTotalFalhaMotivo).forEach((motivo) => {
  console.log(`${motivo}: ${resumoFalha.valorTotalFalhaMotivo[motivo]}`);
});
