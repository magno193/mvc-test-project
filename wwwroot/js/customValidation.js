$(document).ready(function () {
	const labelName = $('[data-label="name"]')[0];
	const labelSurname = $('[data-label="surname"]')[0];
	const labelCpf = $('[data-label="cpf"]')[0];
	const cpf = $('[data-input="cpf"]')[0];
	$('[data-input="cpf"]')
		.on('input', cleaningCpfCnpj)
		.on('change', maskingCpfCnpj);

	const cep = $('[data-address="cep"]')[0];
	$('[data-type]').on('change', function () {
		if (this.value === 'Pessoa Física') {
			labelName.innerText = 'Nome:';
			labelSurname.innerText = 'Sobrenome:';
			labelCpf.innerText = 'CPF:';
			$('[data-group="birthday"]').show().children('input').val('');
			$('[data-input="name"]').val('');
			$('[data-input="surname"]').val('');
			$('[data-input="cpf"]').val('')
				.off().on('input', cleaningCpfCnpj)
				.on('change', maskingCpfCnpj);
		} else {
			labelName.innerText = 'Razão social:';
			labelSurname.innerText = 'Nome fantasia:';
			labelCpf.innerText = 'CNPJ:';
			$('[data-group="birthday"]').hide().children('input').val('0000-00-00');
			$('[data-input="name"]').val('');
			$('[data-input="surname"]').val('');
			$('[data-input="cpf"]').val('')
				.off().on('input', cleaningCpfCnpj)
				.on('change', maskingCpfCnpj);
		}
	});

	function cleaningCpfCnpj() {
		this.value = this.value.replace(/\D/g, '');
		let cpfLenght = $(this)[0].value.length;
		let cpfValue = $(this)[0].value;
		if ($('[data-type]').val() === 'Pessoa Física') {
			if (cpfLenght > 11) {
				let newValue = cpfValue.slice(0, 11);
				$(this).val(newValue);
			}
		} else {
			if (cpfLenght > 14) {
				let newValue = cpfValue.slice(0, 14);
				$(this).val(newValue);
			}
		}
	}

	function maskingCpfCnpj() {
		if ($('[data-type]').val() === 'Pessoa Física') {
			this.value = this.value.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/g, '$1.$2.$3-$4');
		} else {
			this.value = this.value.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/g, '$1.$2.$3/$4-$5');
		}
	}

	// Removes enter default that submits form
	$(document).keypress(
		function (e) {
			if (e.code === 'Enter') {
				e.preventDefault();
			}
		});

	function cleanCepForm() {
		const addressData = $('[data-address]');
		addressData.each((index) => {
			addressData[index].value = '';
		});
	}

	function cepEvents() {
		cep.oninput = function () {
			this.value = this.value.replace(/\D/g, '');
			if (this.value.length > 8) {
				this.value = this.value.slice(0, 8);
			}
		}
		cep.onchange = function () {
			this.value = this.value.replace(/(\d{5})(\d{3})/, '$1-$2');
		}
		cep.onkeypress = function (e) {
			if (e.code === 'Enter') {
				searchApi();
			}
		}
	};
	cepEvents();

	function searchApi() {
		if (!cep.value) {
			alert('O campo de CEP deve ser preenchido!');
			return;
		}
		const cepNumber = cep.value.replace('-', '');
		if (cepNumber.length !== 8) {
			alert('O CEP deve conter 8 números!');
			cleanCepForm();
			return;
		}

		// Fetching data from viacep API
		$.getJSON(`https://viacep.com.br/ws/${cepNumber}/json/`, function (data) {
			// Loading data
			$('[data-address="address-city"]').val('...');
			$('[data-address="address-state"]').val('...');
			$('[data-address="address"]').val('...');
			$('[data-address="address-complement"]').val('...');
			$('[data-address="address-district"]').val('...');
			if (data.erro) {
				alert('CEP inválido!');
				cleanCepForm();
				$('[data-address="cep"]').focus();
				return;
			}
			$('[data-address="address-city"]').val(data.localidade);
			$('[data-address="address-state"]').val(data.uf);
			$('[data-address="address"]').val(data.logradouro);
			$('[data-address="address-number"]').focus();
			$('[data-address="address-complement"]').val(data.complemento);
			$('[data-address="address-district"]').val(data.bairro);
		})
	}
	$('[data-search]').on('click', searchApi);
});
