<template>
    <div class="home-container">
      <h1>📒 Agenda Telefônica</h1>
      <p class="subtitle">Gerencie facilmente suas agendas e contatos.</p>
      <div class="buttons">
        <button @click="$router.push('/contactList')">📁 Listas de Agendas</button>
        <button @click="$router.push('/contact')">📇 Contatos</button>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: 'HomeView'
  }
  </script>
  
  <style scoped>
  .home-container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    min-height: 80vh;
    background-color: #f7f9fc;
    padding: 2rem;
    text-align: center;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  }
  
  h1 {
    font-size: 2.5rem;
    color: #2c3e50;
  }
  
  .subtitle {
    margin-top: 0.5rem;
    color: #7f8c8d;
    font-size: 1.1rem;
  }
  
  .buttons {
    margin-top: 2rem;
    display: flex;
    flex-wrap: wrap;
    gap: 1.2rem;
    justify-content: center;
  }
  
  button {
    padding: 1rem 2rem;
    font-size: 1rem;
    background-color: #2ecc71;
    color: white;
    border: none;
    border-radius: 10px;
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
    cursor: pointer;
    transition: 0.3s ease all;
  }
  
  button:hover {
    background-color: #27ae60;
    transform: translateY(-2px);
  }
  </style>
  