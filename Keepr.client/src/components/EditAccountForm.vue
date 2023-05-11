<template>
  <form @submit.prevent="editAccount()">
    <div class=" my-3">
      <label class="ms-2 my-2" for="editAccountName"><b>Name</b></label>
      <input type="text" class="form-control  form-style" id="editAccountName" placeholder="Name..."
        name="editAccountName" required v-model="editable.name" minlength="3" maxlength="25" />

    </div>
    <div class="bottom-border "></div>
    <div class=" my-3">
      <label class="my-2 ms-2" for="editAccountCoverImg"><b>Cover Image URL</b></label>
      <input type="url" class="form-control form-style" id="editAccountCoverImg" name="editAccountCoverImg" required
        v-model="editable.coverImg" maxlength="500" placeholder=" Cover Image URL..." />

    </div>
    <div class="bottom-border"></div>
    <div class=" my-3">
      <label class="my-2 ms-2 " for="editAccountPicture"><b>Profile Image URL</b></label>
      <input type="url" class="form-control form-style" id="editAccountPicture" name="editAccountPicture" required
        v-model="editable.picture" maxlength="500" placeholder=" Picture URL..." />

    </div>
    <div class="bottom-border"></div>



    <div class="my-3 text-end">
      <button data-bs-dismiss="modal" class="btn btn-success" type="submit">
        Edit Account
      </button>
    </div>
  </form>
</template>


<script>
import { ref, watchEffect } from "vue";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { accountService } from "../services/AccountService.js";
import { AppState } from "../AppState.js";

export default {
  setup() {
    let editable = ref({});
    watchEffect(() => {
      if (AppState.account.id) {
        editable.value = { ...AppState.account }
        AppState.profile = AppState.account
      }
    })
    return {
      editable,
      async editAccount() {
        try {
          const accountData = editable.value
          await accountService.editAccount(accountData)
          editable = ref({})
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