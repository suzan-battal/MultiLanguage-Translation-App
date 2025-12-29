using System;
using MultiLangApp.Services;

namespace MultiLangApp.UI
{
    /**
     * UI Layer (Presentation)
     * Interaction logic for Form1.
     */
    public partial class Form1
    {
        private readonly ITranslationService _translationService;

        public Form1()
        {
            // This would normally be injected via DI
            _translationService = new TranslationService();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize dropdowns
            cmbFrom.Items.AddRange(new[] { "English", "Turkish", "Arabic" });
            cmbTo.Items.AddRange(new[] { "English", "Turkish", "Arabic" });

            cmbFrom.SelectedIndex = 0; // English
            cmbTo.SelectedIndex = 1;   // Turkish
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            string from = cmbFrom.SelectedItem.ToString();
            string to = cmbTo.SelectedItem.ToString();

            // Call Service Layer
            txtOutput.Text = _translationService.Translate(input, from, to);
        }

        // Placeholder for designer methods
        private void InitializeComponent() { }
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Button btnTranslate;
    }
}
