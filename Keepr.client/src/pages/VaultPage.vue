<template>
  <div class="container-fluid" v-if="activeVault">
    <!-- SECTION top -->
    <section class="header-cont">
      <div class="cover-img mt-4 d-flex justify-content-end align-items-center text-light flex-column text-shadow"
        :style="{ backgroundImage: `url(${activeVault.img})`, backgroundPosition: 'center', backgroundSize: 'cover' }">
        <div class="mb-4">
          <h1 class="mb-2">{{ activeVault.name }}</h1>
          <h6>by {{ activeVault.creator.name }}</h6>

        </div>
      </div>
      <div class="d-flex justify-content-end">
        <i class="mdi mdi-dots-horizontal selectable me-2 dropdown-toggle fs-3" data-bs-toggle="dropdown"
          type="button"></i>

        <ul class="dropdown-menu drop-style">
          <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#editAccount">Edit Vault</a></li>
          <div class="dropdown-border"></div>
          <li><a class="dropdown-item" href="#">Another action</a></li>
        </ul>
      </div>
      <div class="d-flex justify-content-center">
        <h5 class="count-style elevation-1">0 Keeps</h5>
      </div>
    </section>

  </div>
</template>


<script>
import { useRoute } from "vue-router";
import Pop from "../utils/Pop.js";
import { vaultsService } from "../services/VaultsService.js";
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";

export default {
  setup() {
    const route = useRoute()
    async function getVaultById() {
      try {
        const vaultId = route.params.vaultId
        logger.log(vaultId)
        await vaultsService.getVaultById(vaultId)
      } catch (error) {
        Pop.error(error)
      }
    }
    onMounted(() => {
      getVaultById()
    })
    return {
      activeVault: computed(() => AppState.activeVault)
    }
  }
}
</script>


<style lang="scss" scoped>
.cover-img {
  height: 20vh;
  width: 100%;
  border-radius: 8px;
}

.count-style {
  background-color: #DED6E9;
  padding: 6px 8px;
  border-radius: 12px;
}

.dropdown-border {
  border-bottom: 1px solid rgb(70, 70, 70);
  width: 80%;
  margin: 0 auto;
}

.drop-style {
  background-color: #DED6E9;
  border: 1.5px solid black;
}

.main-cont {
  width: 65vw;
  margin: 0px auto;
}

.text-shadow {
  text-shadow: 2px 2px 2px black;
}

.header-cont {
  width: 30vw;
  margin: 0px auto;

}
</style>