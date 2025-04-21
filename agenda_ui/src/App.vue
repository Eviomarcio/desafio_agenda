<template>
  <div>
    <nav>
      <router-link to="/contactList">Agendas</router-link>
    </nav>
    <router-view />
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
nav {
  background: #333;
  padding: 1rem;
}
nav a {
  color: #fff;
  margin-right: 1rem;
  text-decoration: none;
}
</style>
