import { TranslationService } from './TranslationService.js';

/**
 * UI Layer (Presentation)
 * Handles DOM interactions and orchestration.
 */
document.addEventListener('DOMContentLoaded', () => {
    // 1. Initialize Service
    const translationService = new TranslationService();

    // 2. DOM Elements
    const txtInput = document.getElementById('txtInput');
    const txtOutput = document.getElementById('txtOutput');
    const cmbFrom = document.getElementById('cmbFrom');
    const cmbTo = document.getElementById('cmbTo');
    const btnTranslate = document.getElementById('btnTranslate');

    // Default Selection (Like C# WinForms)
    cmbFrom.value = "English";
    cmbTo.value = "Turkish";

    /**
     * Translate Button Click Handler
     */
    btnTranslate.addEventListener('click', () => {
        const input = txtInput.value.trim();
        const from = cmbFrom.value;
        const to = cmbTo.value;

        if (!input) {
            txtOutput.value = "";
            return;
        }

        // Call Service Layer
        const result = translationService.translate(input, from, to);

        // Update UI
        txtOutput.value = result;

        // Visual feedback
        txtOutput.style.opacity = '0.5';
        setTimeout(() => {
            txtOutput.style.opacity = '1';
        }, 100);
    });

    // Optional: Real-time translation as you type (can be disabled)
    // txtInput.addEventListener('input', () => {
    //     btnTranslate.click();
    // });
});
