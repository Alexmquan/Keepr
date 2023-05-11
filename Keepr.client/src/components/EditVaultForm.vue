<template>
  <form @submit.prevent="editVault()">
    <div class=" my-3">
      <input type="text" class="form-control  form-style" id="editVaultName" placeholder="Name..." name="editVaultName"
        required v-model="editable.name" minlength="3" maxlength="25" />
      <!-- <label for="name">Name...</label> -->
    </div>
    <div class="bottom-border "></div>
    <div class=" my-3">
      <input type="url" class="form-control form-style" id="editVaultImg" name="editVaultImg" required
        v-model="editable.img" maxlength="500" placeholder="Image URL..." />
      <!-- <label for="img">Image URL...</label> -->
    </div>
    <div class="bottom-border"></div>

    <div class="my-3">
      <textarea name="editVaultDescription" class="form-control form-style" id="editVaultDescription" cols="30" rows="5"
        v-model="editable.description" required maxlength="300" placeholder="Description...">
      </textarea>
      <div class="bottom-border mt-2"></div>
    </div>

    <div class="my-3 text-end">
      <div>
        <p class="mb-1">Private Vaults can only be seen by you</p>

        <div class="d-flex justify-content-end align-items-center mb-2">
          <input type="checkbox" id="editVaultIsPrivate" name="editVaultIsPrivate" class="mb-1" title="make private"
            v-model="editable.isPrivate">
          <h6 class="ms-2">Make Vault Private?</h6>
        </div>

      </div>
      <button data-bs-dismiss="modal" class="btn btn-success" type="submit">
        Edit Vault!
      </button>
    </div>
  </form>
</template>


<script>
import { ref, watchEffect } from "vue";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { AppState } from "../AppState.js";
import { vaultsService } from "../services/VaultsService.js";

export default {
  setup() {
    let editable = ref({});
    watchEffect(() => {
      if (AppState.activeVault?.id) {
        editable.value = { ...AppState.activeVault }
      }
    })
    return {
      editable,
      async editVault() {
        try {
          const vaultId = AppState.activeVault?.id
          const vaultData = editable.value
          await vaultsService.editVault(vaultData, vaultId)
          editable.value = {}
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.form-style {
  border: 0px solid white !important;
  background-color: white;
}

.bottom-border {
  border-bottom: 1px solid rgba(128, 128, 128, 0.589);
}
</style>