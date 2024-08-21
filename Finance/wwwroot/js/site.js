function copyToClipboard(value) {
    // Cria um elemento de texto temporário
    var tempInput = document.createElement("input");
    tempInput.style.position = "absolute";
    tempInput.style.left = "-9999px";
    tempInput.value = value;
    document.body.appendChild(tempInput);

    // Seleciona e copia o valor
    tempInput.select();
    tempInput.setSelectionRange(0, 99999); // Para dispositivos móveis
    document.execCommand("copy");

    // Remove o elemento temporário
    document.body.removeChild(tempInput);

    // Opcional: Mostra uma mensagem de feedback ao usuário
    alert("Código copiado: " + value);
}