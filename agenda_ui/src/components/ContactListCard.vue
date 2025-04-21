<template>
    <div class="contactList-card">
      <h3>{{ contactList.name }}</h3>
      <p>ID: {{ contactList.id }}</p>
  
      <button @click="$emit('open-contact', contactList.id)">Ver Contatos</button>
      <button @click="$emit('edit', contactList)">Editar</button>
      <button @click="$emit('delete', contactList.id)">Excluir</button>
    </div>
  </template>
  
  <script>
  export default {
    name: 'ContactListCard',
    props: {
        contactList: Object
    }
  }
  </script>
  
  <style scoped>
  .contactList-card {
    border: 1px solid #ccc;
    padding: 1rem;
    margin-bottom: 1rem;
    border-radius: 8px;
  }
  button {
    margin-right: 0.5rem;
  }
  </style>
  