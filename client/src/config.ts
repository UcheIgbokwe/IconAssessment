
let config = {
	// Our API is being served
  baseUrl: 'https://localhost:8000/api/',
  // The API specifies that token is generated  at the POST /authenticate endpoint
  loginUrl: 'Account/authenticate',
  // The API serves its tokens with a key of token which differs from
  // aurelia-auth's standard
  tokenName: 'id_token',
  // Once logged in, we want to redirect the user to the welcome view
  loginRedirect: 'welcome',
};

export default config;
