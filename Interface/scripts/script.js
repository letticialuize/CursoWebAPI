var tbody = document.querySelector('table tbody');
		var aluno = {};

		function cadastrar()
		{
			aluno.Nome = document.querySelector('#nome').value;
			aluno.Sobrenome = document.querySelector('#sobrenome').value;
			aluno.Telefone = document.querySelector('#telefone').value;
			aluno.RegistroAcademico = document.querySelector('#ra').value;

			console.log(aluno);

			if(aluno.id === undefined || aluno.id === 0)
				salvarEstudantes('POST', 0, aluno);		
			else
				salvarEstudantes('PUT', aluno.id, aluno);		

			carregaEstudantes();

			$('#exampleModal').modal('hide');
		}

		function novoAluno()
		{
			var btnSalvar = document.querySelector('#btnSalvar');
			var tituloModal = document.querySelector('#tituloModal');

			document.querySelector('#nome').value = '';
			document.querySelector('#sobrenome').value = '';
			document.querySelector('#telefone').value = '';
			document.querySelector('#ra').value = '';

			aluno = {};

			btnSalvar.textContent = 'Cadastrar';
			tituloModal.textContent = 'Cadastrar Aluno';

			$('#exampleModal').modal('show');
		}

		function cancelar()
		{
			var btnSalvar = document.querySelector('#btnSalvar');
			var tituloModal = document.querySelector('#tituloModal');

			document.querySelector('#nome').value = '';
			document.querySelector('#sobrenome').value = '';
			document.querySelector('#telefone').value = '';
			document.querySelector('#ra').value = '';

			aluno = {};

			btnSalvar.textContent = 'Cadastrar';
			tituloModal.textContent = 'Cadastrar Aluno';

			$('#exampleModal').modal('hide');
		}

		function carregaEstudantes()
		{
			tbody.innerHTML = '';

			var xhr = new XMLHttpRequest();

			xhr.open('GET', 'http://localhost:53542/api/Aluno/Recuperar', true);
			xhr.setRequestHeader('Authorization', sessionStorage.getItem('token'));
			
			xhr.onerror = function(){
				console.log('ERROR', xhr.readyState);
			}

			xhr.onreadystatechange = function() 
			{
				if(this.readyState == 4)
				{
					if(this.status == 200)
					{
						var estudantes = JSON.parse(this.responseText);
						for(var indice in estudantes)
							adicionaLinha(estudantes[indice]);
					}
					else if(this.status == 500)
					{
						var erro = JSON.parse(this.responseText);
						console.log(erro.Message);
						console.log(erro.ExceptionMessage);
					}
				}
			}

			xhr.send();
		}

		function salvarEstudantes(metodo, id, corpo)
		{
			var xhr = new XMLHttpRequest();

			if(id === undefined || id === 0)
				id = '';

			xhr.open(metodo, `http://localhost:53542/api/Aluno/${id}`, false);

			if(corpo !== undefined)
			{
				xhr.setRequestHeader('content-type', 'application/json');
				xhr.send(JSON.stringify(corpo));
			}
			else
				xhr.send();	
		}

		function excluirEstudante(id)
		{
			var xhr = new XMLHttpRequest();

			xhr.open('DELETE', `http://localhost:53542/api/Aluno/${id}`, false);

			xhr.send();	
		}

		carregaEstudantes();

		function excluir(estudante)
		{

			bootbox.confirm({
			    message: `Tem certeza que deseja excluir o estudante ${estudante.nome} ?`,
			    buttons: {
			        confirm: {
			            label: 'Sim',
			            className: 'btn-success'
			        },
			        cancel: {
			            label: 'Não',
			            className: 'btn-danger'
			        }
			    },
			    callback: function (result) 
			    {
			        if(result)
					{
						excluirEstudante(estudante.id);
						carregaEstudantes();
					}
			    }
			});

			
		}

		function editarEstudante(estudante)
		{
			var btnSalvar = document.querySelector('#btnSalvar');
			var tituloModal = document.querySelector('#tituloModal');

			document.querySelector('#nome').value = estudante.nome;
			document.querySelector('#sobrenome').value = estudante.sobrenome;
			document.querySelector('#telefone').value = estudante.telefone;
			document.querySelector('#ra').value = estudante.registroAcademico;

			btnSalvar.textContent = 'Salvar';
			tituloModal.textContent = `Editar Aluno ${estudante.nome}`;

			aluno = estudante;



			console.log(aluno);
		}


		
		function adicionaLinha(estudante)
		{

			var trow = `<tr>
							<td>${estudante.nome}</td>
							<td>${estudante.sobrenome}</td>
							<td>${estudante.telefone}</td>
							<td>${estudante.registroAcademico}</td>
							<td>
								<button class="btn btn-info" data-toggle="modal" data-target="#exampleModal" onclick='editarEstudante(${JSON.stringify(estudante)})'> Editar </button>
								<button class="btn btn-danger" onclick='excluir(${JSON.stringify(estudante)})'> Excluir </button>
							</td>
					   	</tr>
					   `
			tbody.innerHTML += trow;
			
		}