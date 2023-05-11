<template>
  <div class="align-items-center bg-light px-3 position-bar bottom-border">

    <!-- <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button> -->

    <!-- SECTION Left side of navbar -->
    <div class="row align-items-center d-flex justify-content-between pt-1 main-cont" id="navbarText">
      <div class="home-btn col-4 d-flex">
        <div class="d-flex align-items-center me-auto remove-border">
          <div class="mobile-display-none">
            <router-link :to="{ name: 'Home' }" class="btn text-dark selectable text-uppercase">
              Home
            </router-link>
          </div>


          <div class="dropdown" v-if="account.id">
            <button class="btn dropdown-toggle selectable" data-bs-toggle="dropdown" aria-expanded="false">
              CREATE<i class="mdi mdi-menu-down"></i>
            </button>
            <ul class="dropdown-menu drop-style">
              <li><a class="dropdown-item selectable" data-bs-toggle="modal" data-bs-target="#createKeep" href="#">Create
                  Keep</a></li>
              <div class="dropdown-border"></div>
              <li><a class="dropdown-item selectable" data-bs-toggle="modal" data-bs-target="#createVault" href="#">Create
                  Vault</a></li>
            </ul>
          </div>

        </div>
      </div>

      <div class="logo col-4 d-flex">
        <router-link class=" d-flex" :to="{ name: 'Home' }">
          <div class="d-flex flex-column align-items-center">
            <img alt="logo" src="../assets/img/KeeprLogo.png" height="45" />
          </div>
        </router-link>
      </div>
      <div class="login logo-mg col-4 d-flex justify-content-end">
        <Login />
      </div>


    </div>
  </div>

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
import { computed } from "vue";
import CreateVaultForm from "./CreateVaultForm.vue";
import Login from './Login.vue'
import SmallModal from "./SmallModal.vue";
import { AppState } from "../AppState.js";
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
.position-bar {
  /* top: auto !important;
    bottom: 0;
    position: fixed;
    display: flex;
    justify-content: space-between;
    width: 100%;
    height: 80px; */
  z-index: 1;
  height: 64px;
}

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

nav {
  height: 64px;
}

.bottom-border {
  border-bottom: 2px solid rgb(190, 190, 190);


}

.dropdown-border {
  border-bottom: 2px solid rgb(70, 70, 70);
  width: 80%;
  margin: 0 auto;
}

/* .navbar-nav .router-link-exact-active {} */

@media screen and (min-width: 768px) {

  .bottom-border {
    border-bottom: 3px solid rgb(190, 190, 190);
  }

  .logo-mg {
    /* margin-right: 2vh; */
  }

  .home-btn {
    order: 1;
    justify-content: start;

  }

  .remove-border {
    border-bottom: none !important;
  }

  .logo {
    order: 2;
    justify-content: center;
    /* margin-right: 3vh; */

  }

  .login {
    order: 3;
  }

  .mobile-display {
    display: none;
  }

}

@media screen and (max-width: 768px) {

  /* nav {
    height: 64px;
    background-color: blue;
  } */




  .mobile-display-none {
    display: none;
  }

  .home-btn {
    order: 2;
    justify-content: center;
    /* padding-bottom: 2vh; */
  }

  .logo {
    order: 1;
    justify-content: start;
    /* padding-bottom: 2vh; */
  }

  .login {
    order: 3;

  }

  /* .position-bar {
    top: auto !important;
    bottom: 0;
    position: fixed;
    display: flex;
    justify-content: space-between;
    width: 100%;
    height: 80px;
    z-index: 1;
    height: 64px;
  } */


}
</style>
