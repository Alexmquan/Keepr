<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-light px-3 position-bar bottom-border">

    <!-- <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button> -->

    <!-- SECTION Left side of navbar -->
    <div class="collapse navbar-collapse justify-content-between row" id="navbarText">
      <div class="col-4 home-btn">
        <ul class="navbar-nav me-auto remove-border">
          <li class="mobile-display-none">
            <router-link :to="{ name: 'Home' }" class="btn text-dark selectable text-uppercase">
              Home
            </router-link>
          </li>
          <li v-if="account.id" class="nav-item dropdown">
            <button class="btn dropdown-toggle selectable" data-bs-toggle="dropdown" aria-expanded="false">
              CREATE <i class="mdi mdi-menu-down mobile-display-none"></i>
            </button>
            <ul class="dropdown-menu drop-style">
              <li><a class="dropdown-item selectable" data-bs-toggle="modal" data-bs-target="#createKeep" href="#">Create
                  Keep</a></li>
              <div class="dropdown-border"></div>
              <li><a class="dropdown-item selectable" data-bs-toggle="modal" data-bs-target="#createVault" href="#">Create
                  Vault</a></li>

            </ul>
          </li>
        </ul>
      </div>

      <div class="logo col-4 d-flex justify-content-center">
        <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
          <div class="d-flex flex-column align-items-center">
            <img alt="logo" src="../assets/img/KeeprLogo.png" height="45" />
          </div>
        </router-link>
      </div>
      <div class="login col-4 d-flex justify-content-end">
        <div class="login-sizing">
          <Login />

        </div>

      </div>
      <!-- LOGIN COMPONENT HERE -->
    </div>
  </nav>

  <SmallModal id="createVault">
    <template #header>
      <div>Add your vault</div>
    </template>
    <template #body>
      <CreateVaultForm />
    </template>
  </SmallModal>
  <SmallModal id="createKeep">
    <template #header>
      <div>Add your keep</div>
    </template>
    <template #body>
      <CreateKeepForm />
    </template>
  </SmallModal>
</template>

<script>
import { AppState } from "../AppState.js";
import CreateVaultForm from "./CreateVaultForm.vue";
import Login from './Login.vue'
import SmallModal from "./SmallModal.vue";
import { computed, onMounted } from 'vue'

export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  },
  components: { Login, SmallModal, CreateVaultForm }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.drop-style {
  background-color: #DED6E9;
  border: 1.5px solid black;
}

.login-sizing {
  width: 2.1vw;
  background: none;
  background-color: white;

}

.dropdown-border {
  border-bottom: 1px solid rgb(70, 70, 70);
  width: 80%;
  margin: 0 auto;
}

/* .navbar-nav .router-link-exact-active {} */

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }

  .bottom-border {
    border-bottom: 2px solid rgb(190, 190, 190);
  }

  /* .dropdown-border {
    border-bottom: 1px solid rgb(70, 70, 70);
    width: 80%;
    margin: 0 auto;
  } */

  .home-btn {
    order: 1;

  }

  .remove-border {
    border-bottom: none !important;
  }

  .logo {
    order: 2;
  }

  .login {
    order: 3;
  }

}

@media screen and (max-width: 768px) {
  nav {
    height: 64px;
    background-color: blue;
  }

  .mobile-display-none {
    display: none;
  }

  .home-btn {
    order: 2;
  }

  .logo {
    order: 1;
  }

  .login {
    order: 3;
  }

  .position-bar {
    top: auto !important;
    bottom: 0;
    position: fixed;
    display: flex;
    justify-content: space-between;
    width: 100%;
    height: 80px;
    z-index: 1;
  }


}
</style>
