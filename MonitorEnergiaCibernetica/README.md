# Monitor de Falhas de Energia com Alerta Cibernético

Este é um sistema desenvolvido em **C# com Windows Forms** que permite o registro, simulação e monitoramento de quedas de energia elétrica, com foco em situações de impacto cibernético, como ataques que comprometem a estabilidade elétrica e causam danos operacionais.

---

## Desenvolvedores
- Lorenzo Ferreira (RM 97318)
- André Lambert (RM 99148)  
- Felipe Cortez (RM 99750)  

---

## Objetivo do projeto

Proteger ambientes críticos de falhas de energia inesperadas, a partir de uma interface simples para:

- Registrar ocorrências reais
- Simular cenários de pane
- Visualizar alertas com base na gravidade
- Emitir relatórios de status
- Detectar eventos suspeitos e gerar logs

---

## Funcionalidades do sistema

- **Registro de Falhas Reais**  
  Cadastro manual de eventos com data, hora, local, tipo e duração de tempo.

- **Simulação de Falhas Cibernéticas**  
  Geração de falhas simuladas para teste de funcionamento do sistema.

- **Alertas visuais de acordo com a gravidade**  
  Classificação automática baseadas na duração:
  - leve
  - moderada
  - crítica

- **Relatório de Falhas Registradas**  
  Tela de consulta aos relatórios das falhas que foram registradas.

- **Registro em Arquivo Local (JSON)**  
  As falhas ficam armanezadas em `dados/falhas.json` para análises futuras.

---

## Estrutura de Pastas do Projeto

```bash
MonitorEnergiaCibernetica/
├── Models/                  # Classes de dados (ex: QuedaEnergia.cs)
│   └── QuedaEnergia.cs
├── Services/                # Lógica de negócio
│   └── RegistroService.cs
├── Forms/                   # Telas do sistema (Windows Forms)
│   ├── MainForm.cs
│   ├── RegistroForm.cs
│   ├── SimulacaoForm.cs
│   └── RelatorioForm.cs
├── dados/                   # Diretório para armazenar o JSON de falhas
│   └── falhas.json
├── Program.cs               # Ponto de entrada do sistema
├── README.md                # Documentação do projeto
└── .gitignore               # Arquivos ignorados pelo Git



---

## Requisitos Funcionais

- Interface visual com formulário para entrada dos dados
- Validação de campos com `try-catch` (datas, campos vazios, numéricos etc.)
- Registro persistente dos dados simulados e reais
- Alertas e diferenciação visual conforme a criticidade

---

## Requisitos Não Funcionais

- Interface intuitiva e leve
- Código limpo com boas práticas
- Modularização entre camadas (modelos, serviços, interface)

---

## Como Executar o Sistema

1. **Abra o projeto no Visual Studio**
2. Compile e execute (F5)
3. o Sistema abrirá a tela principal de login, você pode digitar admin para login e senha.
3. O sistema abrirá a tela de menu com as opções de registro, simulação e relatório, logs e sair.

> **Importante:** os registros ficam salvos localmente em:  
> `bin\Debug\dados\falhas.json`

---

## Aplicações no Mundo Real

- Hospitais, Data Centers e ambientes que exigem continuidade elétrica
- Simulação de impacto de ataques (ex: ransomware em sistemas SCADA)
- Projetos de segurança cibernética

---

## Vídeo de Apresentação do Sistema

▶️ Link do vídeo: https://youtu.be/OvwNTUe92Hw?si=UvQkF_gJ6njxHTIs


