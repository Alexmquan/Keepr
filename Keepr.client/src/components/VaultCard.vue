<template>
  <!-- {{ vault.name }} -->
  <router-link :to="{ name: 'Vault', params: { vaultId: vault.id } }">
    <div class="image-size text-light d-flex justify-content-end flex-column selectable elevation-3"
      v-if="!vault.isPrivate"
      :style="{ backgroundImage: `url(${vault.img})`, backgroundPosition: 'center', backgroundSize: 'cover' }"
      @click="setActiveVault(vault.id)">
      <h2 class="text-shadow mb-4 ms-3">{{ vault.name }}</h2>
      <div class="" v-if="vault.isPrivate"><i class="mdi mdi-lock"></i></div>
    </div>

    <div class="image-size text-light d-flex justify-content-end flex-column selectable elevation-3"
      v-else-if="vault.creator.id == account.id && vault.isPrivate"
      :style="{ backgroundImage: `url(${vault.img})`, backgroundPosition: 'center', backgroundSize: 'cover' }">
      <div class="d-flex justify-content-between">
        <h2 class="text-shadow mb-4 ms-3">{{ vault.name }}</h2>
        <div class=""><i class="mdi mdi-lock fs-3 text-shadow me-4"></i></div>

      </div>
    </div>
  </router-link>
</template>


<script>
import { computed } from "vue";
import { Vault } from "../models/Vault.js";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { vaultsService } from "../services/VaultsService.js";

export default {
  props: {
    vault: {
      type: Vault,
      required: true
    }
  },
  setup() {
    return {
      account: computed(() => AppState.account),
      async setActiveVault(vaultId) {
        try {
          await vaultsService.setActiveVault(vaultId)
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
@media screen and (min-width: 768px) {
  .image-size {
    width: 18vw;
    height: 25vh;
    border-radius: 8px;
  }

  .text-shadow {
    text-shadow: 2px 2px 2px black;
  }
}

@media screen and (max-width: 768px) {
  .image-size {
    width: 70vw;
    height: 25vh;
    border-radius: 8px;
  }
}
</style>