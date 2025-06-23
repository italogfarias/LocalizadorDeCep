# Localizador de CEP

## Descrição
O **Localizador de CEP** é uma aplicação Windows Forms desenvolvida em C# no Visual Studio que permite consultar informações de endereços a partir de um CEP (Código de Endereçamento Postal) brasileiro. A aplicação utiliza a API pública do **ViaCEP** para obter os dados e exibi-los em uma interface gráfica.

## Funcionalidades
- **Consulta de CEP**: Insira um CEP válido (8 dígitos, sem hífen) e obtenha informações como:
  - Logradouro
  - Bairro
  - Complemento
  - Localidade (cidade)
  - Estado
  - UF
  - DDD
  - Região
  - Unidade (se aplicável)
- **Validação de CEP**: Verifica se o CEP possui 8 dígitos antes de realizar a consulta.
- **Tratamento de Erros**:
  - Exibe mensagem de erro se o CEP for inválido.
  - Exibe mensagem se o CEP não for encontrado na API.
- **Interface Gráfica**: Exibe os resultados em labels na interface do Windows Forms.

## Tecnologias Utilizadas
- **Linguagem**: C#
- **Framework**: .NET Framework (Windows Forms)
- **IDE**: Visual Studio
- **Bibliotecas**:
  - `System.Net.WebClient`: Para realizar requisições HTTP à API ViaCEP.
  - `Newtonsoft.Json`: Para desserializar o JSON retornado pela API em um objeto C#.
- **API**: [ViaCEP](https://viacep.com.br/)

## Pré-requisitos
- Visual Studio (qualquer versão compatível com Windows Forms e .NET Framework).
- .NET Framework instalado.
- Pacote NuGet `Newtonsoft.Json` instalado no projeto.
- Conexão com a internet para acessar a API ViaCEP.

## Como Executar
1. **Clonar o Repositório** (se aplicável):
   ```bash
   git clone <URL_DO_REPOSITORIO>
   ```
2. **Abrir o Projeto**:
   - Abra o arquivo `.sln` no Visual Studio.
3. **Instalar Dependências**:
   - No Gerenciador de Pacotes NuGet, instale o `Newtonsoft.Json`:
     ```bash
     Install-Package Newtonsoft.Json
     ```
4. **Compilar e Executar**:
   - Pressione `F5` ou clique em "Iniciar" no Visual Studio.
5. **Usar a Aplicação**:
   - Insira um CEP válido (exemplo: `01001000`) no campo de texto.
   - Clique no botão "Buscar" para consultar as informações.
   - Os dados do endereço serão exibidos nas labels correspondentes.

## Estrutura do Código
- **Namespace**: `LocalizadorDeCep`
- **Classe Principal**: `Form1` (Windows Forms)
- **Método Principal**: `btnBuscar_Click`
  - Realiza a validação do CEP.
  - Faz a requisição à API ViaCEP.
  - Desserializa o JSON em um objeto `Endereco`.
  - Exibe os dados na interface ou mensagens de erro, se necessário.
- **Classe Auxiliar**: `Endereco` (não fornecida no trecho, mas deve conter propriedades como `Cep`, `Logradouro`, `Bairro`, etc., correspondentes ao JSON retornado pela API).

## Exemplo de Uso
1. Insira o CEP `01001000` no campo de texto.
2. Clique em "Buscar".
3. Resultado esperado:
   - CEP: 01001-000
   - Logradouro: Praça da Sé
   - Bairro: Sé
   - Localidade: São Paulo
   - UF: SP
   - DDD: 11
   - etc.

## Limitações
- A aplicação não suporta CEPs com hífen (ex.: `01001-000`). O usuário deve inserir apenas os 8 dígitos.
- Não há tratamento para falhas de conexão com a internet (pode ser implementado com `try-catch`).
- A classe `Endereco` não foi fornecida no código, mas é necessária para a desserialização do JSON.

## Possíveis Melhorias
- Adicionar suporte a CEPs com hífen, removendo-o automaticamente.
- Implementar um `try-catch` para tratar erros de rede ou API indisponível.
- Adicionar um campo para busca por endereço (reversa) usando outros endpoints do ViaCEP.
- Melhorar a interface gráfica com um design mais moderno.

## Contribuições
Contribuições são bem-vindas! Para sugerir melhorias ou corrigir bugs:
1. Fork o repositório.
2. Crie uma branch para sua feature (`git checkout -b feature/nova-funcionalidade`).
3. Faça commit das suas alterações (`git commit -m 'Adiciona nova funcionalidade'`).
4. Push para a branch (`git push origin feature/nova-funcionalidade`).
5. Abra um Pull Request.

## Licença
Este projeto é distribuído sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes (se aplicável).

## Contato
Para dúvidas ou sugestões, entre em contato pelo e-mail: [seu-email@example.com] ou abra uma issue no repositório.