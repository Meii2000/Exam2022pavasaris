﻿using System;
using System.IO;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string chromeDriverPath = "chromedriver.exe";
        private IWebDriver driver; 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSerch.Text;
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, chromeDriverPath);        
            driver = new ChromeDriver(absolutePath);
            driver.Navigate().GoToUrl("https://www.ebay.com/");
            var searchField = driver.FindElement(By.Id("gh-ac"));
            searchField.SendKeys(searchTerm);
            var searchButton = driver.FindElement(By.Id("gh-btn"));
            searchButton.Click();
            string searchResultUrl = driver.Url;
            lstSearchResults.Items.Add(searchResultUrl);         
            Console.WriteLine($"Результат поиска: {searchResultUrl}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (driver != null)
            {
                driver.Quit();
            }
        }

        private void txtSerch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (driver != null)
            {
                driver.Navigate().Back();
                txtSerch.Text = "";
                lstSearchResults.Items.Clear();
            }
        }
    }
}


