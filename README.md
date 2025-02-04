# 📚 ISBN Helper - Um Presente para Minha Amada 💖

*"Por trás de cada livro há uma história, e por trás deste código há um coração que te ama."* ❤️

<div align="center">
  <img src="https://media.giphy.com/media/MDJ9IbxxvDUQM/giphy.gif?cid=82a1493bk07sxf6uaqn5kjx48rmlsmlhgs4ixjrbno58waxs&ep=v1_gifs_trending&rid=giphy.gif&ct=g" width="300">
</div>

## 🌟 O Que Faz Este Projeto?
Automatiza a pesquisa de informações de livros através do ISBN diretamente no site da CBL (Câmara Brasileira do Livro), gerando um arquivo CSV pronto para importação no Goodreads!

- **🕵️ Coleta Automática** de Título, Autor, Editora e Ano
- **📁 Processamento de Arquivos** TXT/CSV
- **🤖 Navegação Web Automatizada** com ChromeDriver
- **💾 Exportação Formatada** para CSV do Goodreads
- **🎁 Presente Especial** para organizar a biblioteca virtual de alguém muito especial

## 🛠️ Como Usar?
-  Clone o repositório
-  Instale o .NET 7 SDK
-  Baixe o ChromeDriver correspondente à sua versão do Chrome
-  Configure os caminhos nos campos inputFilePath e outputFilePath
-  Execute o programa!

## 🎨 Personalização
-   📂 Arquivo de Configuração
string inputFilePath = @"SEU_ARQUIVO_DE_ENTRADA.txt";
string outputFilePath = @"SAIDA.csv";
-  🎯 Parâmetros de Busca
string searchUrl = "https://www.cblservicos.org.br/isbn/pesquisa/";
//📊 Cabeçalho do CSV (Adicione novas colunas conforme necessário)
-  writer.WriteLine("Book Id,Title,Author,ISBN,ISBN13,My Rating,Exclusive Shelf,Publisher,Year Published");

<div align="center">
  <img src="https://media.giphy.com/media/JIX9t2j0ZTN9S/giphy.gif?cid=790b7611jwv1gqnpf40qfxnwktqp3ssouu10wpcvmlsmo6ws&ep=v1_gifs_search&rid=giphy.gif&ct=g" width="400">
</div>

## 💡 Dicas Importantes
- **⚠️ Mantenha o ChromeDriver atualizado** (versão deve bater com seu Chrome)
- **⏳ Intervalos de delay** podem precisar de ajuste conforme conexão
- **📌 Adicione a coluna 'Shelves'** caso esteja importando os livros que você pretende ler
- **💌 Formate o CSV** com os campos específicos conforme a necessidade

## 🚀 Tecnologias Usadas
| Ferramenta | Função |
|------------|--------|
|   .NET 8 | Backend principal |
|   Selenium | Automação web |
|   ChromeDriver | Controle do navegador |

## 💌 Nota Especial
> *"Cada linha de código deste projeto foi escrita com o mesmo cuidado com que escolho as palavras para te dizer o quanto te amo. Que possamos viver nossas próprias histórias, que são muito mais belas que qualquer ficção."*

<div align="center">
  <img src="https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExZ2R0bzV0NXFlOWJkeTkzYTMyajVzN2g2Nmx5cG5mMnBiMnFhM3RiZiZlcD12MV9naWZzX3NlYXJjaCZjdD1n/rKXbXooKRaFWg/giphy.gif" width="300">
</div>

## 📄 Licença
MIT License - Livre para uso e personalização, mas mantenha o ❤️ original!

