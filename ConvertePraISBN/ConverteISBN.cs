using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ISBNHelp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string inputFilePath = @""; //Caminho do arquivo de entrada contendo os dados a serem pesquisados.
            string outputFilePath = @""; //Caminho do arquivo de saída contendo os dados coletados e formatados.
            string searchUrl = "https://www.cblservicos.org.br/isbn/pesquisa/"; //Você pode alterar caso tenha alguma fonte melhor para pesquisar os ISBNs, mas lembre-se, que alterar isso vai demandar um remapeamento dos icones e classes no código.

            HashSet<string> uniqueItems = new HashSet<string>();
            StringBuilder currentItem = new StringBuilder();

            foreach (var line in File.ReadLines(inputFilePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    currentItem.Append(line + " ");
                    if (line.EndsWith(";"))
                    {
                        uniqueItems.Add(currentItem.ToString().Trim());
                        currentItem.Clear();
                    }
                }
            }

            ChromeOptions options = new ChromeOptions();
            options.AddArgument(@""); 

            using (IWebDriver driver = new ChromeDriver(options))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine("Book Id,Title,Author,ISBN,ISBN13,My Rating,Exclusive Shelf,Publisher,Year Published"); //Aqui é a base do CSV, você pode alterar, e adicionar a coluna "Shelves", colocando o valor fixo de "to-read", isso vai viabilizar importar direto para o to-read, no goodreads.

                    foreach (string item in uniqueItems)
                    {
                        try
                        {
                            driver.Navigate().GoToUrl(searchUrl);

                            await Task.Delay(1000); 

                            IWebElement searchField = driver.FindElement(By.Id("pesquisar"));
                            searchField.SendKeys(item);

                            IWebElement searchButton = driver.FindElement(By.Id("search-button"));
                            searchButton.Click();

                            await Task.Delay(1000); 

                            IWebElement firstResult = driver.FindElement(By.CssSelector(".listagem .k2m-search"));
                            string title = firstResult.FindElement(By.CssSelector("b.title")).Text;
                            string author = firstResult.FindElement(By.CssSelector(".autores")).Text.Split(',')[0].Trim(); string isbn = firstResult.FindElement(By.CssSelector(".isbn")).Text.Replace("-", ""); 
                            string publisher = firstResult.FindElement(By.CssSelector(".editoras")).Text;
                            string yearPublished = firstResult.FindElement(By.CssSelector(".ano")).Text;

                            title = title.Replace("\n", "").Replace("\r", "").Trim();
                            publisher = publisher.Replace("\n", "").Replace("\r", "").Trim();
                            yearPublished = yearPublished.Replace("\n", "").Replace("\r", "").Trim();

                            writer.WriteLine($"\"\",\"{title}\",\"{author}\",\"{isbn}\",\"\",\"\",\"\",\"{publisher}\",\"{yearPublished}\""); //o valor fixo de shelves deve ser adicionado aqui, caso você tenha optado por adicionar a coluna.
                            writer.Flush(); 

                            await Task.Delay(1000);
                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine($"Nenhum resultado encontrado para: {item}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao processar {item}: {ex.Message}");
                        }
                    }
                }
            }

            Console.WriteLine($"Os dados foram coletados e armazenados em {outputFilePath}");
        }
    }
}