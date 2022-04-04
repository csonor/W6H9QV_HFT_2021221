let countries = [];

fetch('http://localhost:7649/country')
	.then(x => x.json())
	.then(y => {
		countries = y;
		display();
		console.log(y);
	});

function display() {
	countries.forEach(x => {
		document.getElementById('results').innerHTML +=
			"<tr><td>" + x.id + "</td><td>"
			+ x.name + "</td><td>"
			+ x.englishName + "</td><td>"
			+ x.countryCode + "</td><td>"
			+ x.population + "</td><td>"
			+ x.currency + "</td><td>"
			+ x.drivingSide + "</td></tr>";
	})
}

function create() {
	let name = document.getElementById('countryName')
}