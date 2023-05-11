<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer>

  </footer>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import Pop from "./utils/Pop.js"
import { accountService } from "./services/AccountService.js"

export default {
  setup() {
    // const profileId = AppState.account.id
    // async function getProfile() {
    //   try {
    //     await accountService.getProfile(profileId)
    //   } catch (error) {
    //     Pop.error(error)
    //   }
    // }
    // onMounted(() => {
    //   getProfile()
    // })
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
@import url('https://fonts.googleapis.com/css2?family=Marko+One&display=swap');

body {

  font-family: 'Marko One', serif;
}

.noSelect {
  user-select: none;
}

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  // display: grid;
  // place-content: center;
  // height: 32px;
}

@media screen and (min-width: 768px) {
  .mobile-display {
    display: none;

  }

}

@media screen and (max-width: 768px) {
  .no-mobile-display {
    display: none;
  }
}
</style>
