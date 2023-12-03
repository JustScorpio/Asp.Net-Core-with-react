import logo from './logo.svg';
import './App.css';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { JsonToTable } from "react-json-to-table";

function App() {

  const [weather, setWeather] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:7143/WeatherForecast')
      .then(response => {
        setWeather(response.data);
      })
      .catch(error => {
        console.error(error);
      });
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <div>
          <JsonToTable json={weather} />
        </div>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
