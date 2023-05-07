<template>
  <!-- <div class="card text-bg-dark  card-style col-3"> -->
  <div>
    <img :src="keep.img" class="elevation-4 card-image" alt="...">
    <div class="card-img-overlay d-flex justify-content-end flex-column content-style">
      <div class="d-flex justify-content-between">
        <h5 class="card-title text-light text-shadow">{{ keep.name }}</h5>
        <router-link :to="{ name: 'Profile', params: { profileId: keep.creator.id } }">
          <img class="profile-style ms-5" :src="keep.creator.picture" alt="" :title="keep.creator.name">

        </router-link>
      </div>
    </div>

  </div>
</template>


<script>
import { Keep } from "../models/Keep.js";

export default {
  props: {
    keep: {
      type: Keep,
      required: true
    }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
// img {
//   width: 18vw;
//   object-fit: contain;
//   border-radius: 8px;
// }

.card-image {
  width: 18vw;
  object-fit: contain;
  border-radius: 8px;
}

// .image-style {
//   width: 18vw;
//   object-fit: contain;
//   height: 100%;
// }

.text-shadow {
  text-shadow: 2px 2px 2px black;
}

.profile-style {
  height: 5vh;
  width: 5vh;
  border-radius: 50%;
}

// .content-style {
//   width: 100%;
// }
</style>