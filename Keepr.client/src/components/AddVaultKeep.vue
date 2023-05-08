<template>
  <div>
    <li><a class="dropdown-item selectable" title="Add activity to your trip" @click="addKeepToVault(vault.id)">{{
      vault.name }}</a></li>
  </div>
</template>


<script>
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
  setup() {
    return {
      async addKeepToVault(vaultId) {
        try {
          const keepId = AppState.activeKeep.id
          const vaultKeepData = {
            vaultId: vaultId,
            keepId: keepId
          }
          await vaultKeepService.addKeepToVault(vaultKeepData)
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>