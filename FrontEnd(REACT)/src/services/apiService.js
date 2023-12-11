import { API_ENDPOINT } from "../utils/constants"


const GetHeaders = () => {
  const headers = {
    "Content-Type": "application/json",
  };

  const token = localStorage.getItem('token');
  if (token) {
    headers.Authorization = `Bearer ${token}`;
  }

  return headers;
};

const HandleUnauthorized = async (requestType, response, endpoint, requestOptions) => {
  localStorage.removeItem("token");
  GoToHomePage();
  throw new Error(`${requestType} request failed with status: ${response.status}`);
}


const GoToHomePage = () => {
  const currentURL = window.location.href;
  const currentDomain = window.location.protocol + '//' + window.location.host;

  if (currentURL !== currentDomain && currentURL !== currentDomain + '/')
  {
    window.location.href = currentDomain;
  }
}


export const apiService = {
  get: async (endpoint, data) => {
    try {
      let requestOptions = {
        method: 'GET',
        headers: GetHeaders()
      };
      if (data) {
        requestOptions.body = JSON.stringify(data)
      }

      const response = await fetch(`${API_ENDPOINT}/${endpoint}`, requestOptions);
      if (!response.ok) {
        if (response.status == 401) {
          await HandleUnauthorized('POST', response, endpoint, requestOptions);
        }
        throw new Error(`GET request failed with status: ${response.status}`);
      }
      return (await response.json()).result;
    } catch (error) {
      console.error('API error:', error.message);
      throw error;
    }
  },
  post: async (endpoint, data) => {
    try {
      let requestOptions = {
        method: 'POST',
        headers: GetHeaders(),
        body: JSON.stringify(data),
      }

      const response = await fetch(`${API_ENDPOINT}/${endpoint}`, requestOptions);

      if (!response.ok) {
        if (response.status == 401) {
          await HandleUnauthorized('POST', response);
        }
      }
      return;
      return (await response.json()).result;
    } catch (error) {
      console.error('API error:', error.message);
      throw error;
    }
  },

  put: async (endpoint, data) => {
    try {
      let requestOptions = {
        method: 'PUT',
        headers: GetHeaders(),
        body: JSON.stringify(data),
      };

      const response = await fetch(`${API_ENDPOINT}/${endpoint}`, requestOptions);

      if (!response.ok) {
        if (response.status == 401) {
          await HandleUnauthorized('PUT', response);
        }
        throw new Error(`PUT request failed with status: ${response.status}`);
      }
      return (await response.json()).result;
    } catch (error) {
      console.error('API error:', error.message);
      throw error;
    }
  },

  delete: async (endpoint, data) => {
    try {
      let requestOptions = {
        method: 'DELETE',
        headers: GetHeaders()
      }

      if (data) {
        requestOptions.body = JSON.stringify(data)
      }
      const response = await fetch(`${API_ENDPOINT}/${endpoint}`, requestOptions);

      if (!response.ok) {
        if (response.status == 401) {
          await HandleUnauthorized('DELETE', response);
        }
        throw new Error(`DELETE request failed with status: ${response.status}`);
      }
      return;
      return (await response.json()).result;
    } catch (error) {
      console.error('API error:', error.message);
      throw error;
    }
  },
};