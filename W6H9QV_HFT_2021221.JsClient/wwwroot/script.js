let countries = [];

getdata();

async function getdata() {
	await
		fetch('http://localhost:7649/country')
			.then(x => x.json())
			.then(y => {
				countries = y;
				display();
				console.log(y);
			});
}

function display() {
	document.getElementById('results').innerHTML = "";
	countries.forEach(x => {
		document.getElementById('results').innerHTML +=
			"<tr><td>" + x.id + "</td><td>"
			+ x.name + "</td><td>"
			+ x.englishName + "</td><td>"
			+ x.countryCode + "</td><td>"
			+ x.population + "</td><td>"
			+ x.currency + "</td><td>"
			+ x.drivingSide + "</td><td>"
			+ `<button type="button"onclick="remove(${x.id})">Remove</button>` + "</td></tr>";
	})
}

function create() {
	let Cname = document.getElementById('name').value;
	let CenglishName = document.getElementById('englishName').value;
	let CcountryCode = document.getElementById('countryCode').value;
	let Cpopulation = document.getElementById('population').value;
	let Ccurrency = document.getElementById('currency').value;
	let CdrivingSide = document.getElementById('drivingSide').value;

	fetch('http://localhost:7649/country', {
		method: 'POST',
		headers: { 'Content-Type': 'application/json', },
		body: JSON.stringify(
			{
				name: Cname,
				englishName: CenglishName,
				countryCode: CcountryCode,
				population: Number(Cpopulation),
				currency: Ccurrency,
				drivingSide: Number(CdrivingSide)
			})
	})
		.then(response => response)
		.then(data => {
			console.log('Success:', data);
			getdata();
		})
		.catch((error) => { console.error('Error:', error); });

	document.getElementById('name').value = "";
	document.getElementById('englishName').value = "";
	document.getElementById('countryCode').value = "";
	document.getElementById('population').value = "";
	document.getElementById('currency').value = "";
	document.getElementById('drivingSide').value = "";
}

function remove(id) {
	fetch('http://localhost:7649/country/delid/' + id, {
		method: 'DELETE',
		headers: { 'Content-Type': 'application/json', },
		body: null
	})
		.then(response => response)
		.then(data => {
			console.log('Success:', data);
			getdata();
		})
		.catch((error) => { console.error('Error:', error); });
}