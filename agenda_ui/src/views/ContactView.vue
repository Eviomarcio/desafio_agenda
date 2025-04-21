<template>
    <div>
      <h1>Contatos da Agenda {{ contactListId }}</h1>
      <!-- Aqui vai vir a listagem dos contatos -->
    </div>
  </template>
  
  <script>
  export default {
    name: 'ContatosView',
    props: ['contactListId']
  }
  </script>
  