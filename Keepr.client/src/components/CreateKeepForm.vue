<template>
  <form @submit.prevent="createTrip()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="name" placeholder="Name" name="name" required v-model="editable.name"
        minlength="3" maxlength="25" />
      <label for="name">Name</label>
    </div>

    <div class="form-floating mb-3">
      <input type="date" class="form-control" id="start" placeholder="Start Date" name="start" required
        v-model="editable.start" :min="today" />
      <label for="start">Start Date</label>
    </div>
    <div class="form-floating mb-3">
      <input type="date" class="form-control" id="end" placeholder="End Date" name="end" required v-model="editable.end"
        :min="editable.start" />
      <label for="end">End Date</label>
    </div>

    <div class="form-floating mb-3">
      <input type="url" class="form-control" id="mgUrl" placeholder="ImgUrl" name="imgUrl" v-model="editable.coverImg"
        @input="previewImage" />
      <label for="imgUrl">Trip Cover Photo</label>
      <br />
      <img :src="imagePreview" v-if="imagePreview" style="max-width: 100%" />
    </div>
    <div class="form-floating mb-3">
      <textarea class="form-control" id="description" placeholder="Description" name="description" required
        style="height: 100px" v-model="editable.description" minlength="5" maxlength="1000"></textarea>
      <label for="description">Description</label>
    </div>
    <div class="my-3 text-end">
      <button data-bs-dismiss="modal" class="btn btn-success" type="submit">
        Create!
      </button>
    </div>
  </form>
</template>


<script>
export default {
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped></style>