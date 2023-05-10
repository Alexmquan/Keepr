<template>
  <form @submit.prevent="createVault()">
    <div class=" my-3">
      <input type="text" class="form-control  form-style" id="name" placeholder="Name..." name="name" required
        v-model="creatable.name" minlength="3" maxlength="25" />
      <!-- <label for="name">Name...</label> -->
    </div>
    <div class="bottom-border "></div>
    <div class=" my-3">
      <input type="url" class="form-control form-style" id="img" name="img" required v-model="creatable.img"
        maxlength="500" placeholder="Image URL..." />
      <!-- <label for="img">Image URL...</label> -->
    </div>
    <div class="bottom-border"></div>

    <div class="my-3">
      <textarea name="description" class="form-control form-style" id="description" cols="30" rows="5"
        v-model="creatable.description" required maxlength="300" placeholder="Description..." title="Description">
      </textarea>
      <div class="bottom-border mt-2"></div>
    </div>

    <div class="my-3 text-end">
      <div>
        <p class="mb-1">Private Vaults can only be seen by you</p>

        <div class="d-flex justify-content-end align-items-center mb-2">
          <input type="checkbox" id="isPrivate" name="isPrivate" class="mb-1" title="make private"
            v-model="creatable.isPrivate">
          <h6 class="ms-2">Make Vault Private?</h6>
        </div>

      </div>
      <button data-bs-dismiss="modal" class="btn btn-success" type="submit">
        Create Vault!
      </button>
    </div>
  </form>
</template>


<script>
import { ref } from "vue";
import { vaultsService } from "../services/VaultsService.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";

export default {
  setup() {
    let creatable = ref({});
    return {
      creatable,
      async createVault() {
        try {
          const vaultData = creatable.value
          await vaultsService.createVault(vaultData)
          // creatable = ref({})
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