$(document).ready(function() {
    $.ajax({
        url: 'https://localhost:7228/api/ProblemaSaude/GetListProblema',
        type: 'GET',
        dataType: 'json',
        success: function(data) {
            console.log(data); // Verifica a estrutura do retorno
            const selectProblemas = $('#problemas');

            // Acessa a propriedade $values para iterar sobre a lista de problemas
            const problemas = data.$values || [];  // Evita erro caso $values não exista
            if (Array.isArray(problemas)) {
                problemas.forEach(function(problema) {
                    const option = new Option(problema.nome, problema.id); // Nome e ID como valores de exemplo
                    selectProblemas.append(option);
                });
            } else {
                console.error('O formato da resposta não é uma lista válida.');
            }
        },
        error: function(error) {
            console.error('Erro ao carregar problemas de saúde:', error);
        }
    });
    carregarClientes();
});

$('#BtnCadastroCliente').click(function(event) {
    event.preventDefault(); 

    const nome = document.getElementById('nome').value;
    const nascimento = document.getElementById('nascimento').value;
    const sexoCliente = document.getElementById('sexo').value;
    const altura = parseFloat(document.getElementById('altura').value);
    const peso = parseFloat(document.getElementById('peso').value);
    const problemasDeSaude = Array.from(document.getElementById('problemas').selectedOptions).map(option => option.value);
    const formData = {
      nome: nome,
      nascimento: nascimento,
      sexoCliente: parseInt(sexoCliente),
      altura: altura,
      peso: peso,
      problemasDeSaudeIds: problemasDeSaude.map(id => parseInt(id))
    };

        console.log(formData);
    fetch('https://localhost:7228/api/Cliente/AddCliente', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    })
    .then(response => response.json())
    .then(data => {
        $('#response').html('<p>' + data.message + '</p>');
        alert("Cliente cadastrado com sucesso");
        window.location.href = '/html/Index.html';

    })
    .catch(error => {
        $('#response').html('<p>There was an error: ' + error + '</p>');
    });
});


function carregarClientes() {
  $.ajax({
    url: 'https://localhost:7228/api/Cliente/GetListaCliente', 
    method: 'GET',
    dataType: 'json', 
    success: function(response) {
      $('#clientesBody').empty();
      if (response && Array.isArray(response.$values)) {     
        response.$values.forEach(function(cliente) {
            console.log(cliente);
           var sexo = (parseInt(cliente.sexoCliente) === 1) ? "Masculino" : "Feminino";
          var row = `
            <tr>
              <td>${cliente.id}</td>
              <td>${cliente.nome}</td>
              <td>${cliente.nascimento}</td>
              <td>${sexo}</td>
              <td>${cliente.altura}</td>
              <td>${cliente.peso}</td>
              <td>
                <button class="btn btn-info btn-sm btn-editar" data-id="${cliente.id}">Editar</button>
                <button class="btn btn-danger btn-sm btn-excluir" data-id="${cliente.id}">Excluir</button>
              </td>
            </tr>
          `;
          $('#clientesBody').append(row);
        });
      } else {
        console.log(response);
        console.error("A resposta da API não é um array de clientes.");
      }
    },
    error: function(xhr, status, error) {
      console.error('Erro ao carregar os clientes:', error);
      alert('Houve um erro ao tentar carregar a lista de clientes. Tente novamente mais tarde.');
    }
  });
}
