<template>
  <form @submit.prevent="editAccount()">
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
      <button data-bs-dismiss="modal" class="btn btn-success" type="submit">
        Create!
      </button>
    </div>
  </form>
</template>


<script>
import { ref } from "vue";
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";

export default {
  setup() {
    let creatable = ref({});
    return {
      creatable,
      async createKeep() {
        try {
          const keepData = creatable.value
          await keepsService.createKeep(keepData)
          creatable = ref({})
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