<template>
  <form @submit.prevent="editAccount()">
    <div class=" my-3">
      <label class="ms-2 my-2" for="name">Name</label>
      <input type="text" class="form-control  form-style" id="name" placeholder="Name..." name="name" required
        v-model="editable.name" minlength="3" maxlength="25" />

    </div>
    <div class="bottom-border "></div>
    <div class=" my-3">
      <label class="my-2 ms-2" for="img">Cover Image URL</label>
      <input type="url" class="form-control form-style" id="coverImg" name="coverImg" required v-model="editable.coverImg"
        maxlength="500" placeholder=" Cover Image URL..." />

    </div>
    <div class="bottom-border"></div>
    <div class=" my-3">
      <label class="my-2 ms-2 " for="img">Profile Image URL</label>
      <input type="url" class="form-control form-style" id="picture" name="picture" required v-model="editable.picture"
        maxlength="500" placeholder=" Picture URL..." />

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