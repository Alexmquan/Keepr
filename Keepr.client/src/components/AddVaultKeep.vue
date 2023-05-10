<template>
  <div v-if="!alreadyAdded">
    <li><a class="dropdown-item selectable" title="Add keep to your vault" @click="addKeepToVault(vault.id)">{{
      vault.name }}</a></li>
  </div>
  <div v-else-if="alreadyAdded">
    <li><a class="dropdown-item red" title="This Keep is already in this vault">{{
      vault.name }}</a></li>
  </div>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
import { Vault } from "../models/Vault.js";
import { vaultKeepService } from "../services/VaultKeepService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {
    vault: {
      type: Vault,
      required: true
    }
  },
  setup(props) {

    return {
      props,
      alreadyAdded: computed(() => AppState.vaultKeeps.some(vk =>
        (vk.vaultId == props.vault.id && vk.keepId == AppState.activeKeep.id)
      )),
      async addKeepToVault(vaultId) {
        try {
          const keepId = AppState.activeKeep.id
          const vaultKeepData = {
            vaultId: vaultId,
            keepId: keepId
          }
          // const addedKeep = AppState.activeKeep
          // addedKeep.kept++
          await vaultKeepService.addKeepToVault(vaultKeepData)
          // await keepsService.editKeep(addedKeep)
          Pop.toast(`Keep added to ${props.vault.name}`, 'success', 'top')
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.red {
  color: rgb(232, 99, 99);
}
</style>