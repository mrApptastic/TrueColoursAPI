export async function getNearestColour(red, green, blue) {
  const response = await fetch(
    'https://colours.tesj.dk/Hex/' +
      red +
      '/' +
      green +
      '/' +
      blue +
      '?take=10',
    {
      method: 'GET',
      mode: 'cors',
      headers: {
        'Content-Type': 'application/json',
      },
    }
  );
  return response.json();
}

export async function searchColours(searchText, page, take, types) {
  const response = await fetch(
    '"https://colours.tesj.dk/Hex/Search?page=' + page + '&take=' + take + '"',
    {
      method: 'POST',
      mode: 'cors',
      headers: {
        'Content-Type': 'application/json',
      },
      body: {
        name: searchText,
        types: types,
      },
    }
  );
  return response.json();
}

export async function getTypes() {
  const response = await fetch('https://colours.tesj.dk/ColourType', {
    method: 'GET',
    mode: 'cors',
    headers: {
      'Content-Type': 'application/json',
    },
  });
  return response.json();
}
