<template>
  <!-- <div class="card text-bg-dark  card-style col-3"> -->
  <div data-bs-toggle="modal" data-bs-target="#keepModal" @click="setActiveKeep(keep?.id)">
    <img :src="keep.img" class="elevation-4 card-image" alt="...">
    <div class="card-img-overlay d-flex justify-content-end flex-column content-style">
      <div class="d-flex justify-content-between align-items-center">
        <h5 class="card-title text-light text-shadow">{{ keep.name }}</h5>
        <router-link :to="{ name: 'Profile', params: { profileId: keep.creator.id } }">
          <img class="profile-style ms-5" :src="keep.creator.picture" alt="" :title="keep.creator.name">

        </router-link>
      </div>
    </div>

  </div>

  <LargeModal id="keepModal">
    <!-- <template #header>
      <div>Edit your Account</div>
    </template> -->
    <template #body>
      <ActiveKeepCard />
    </template>
  </LargeModal>
</template>


<script>
import { Keep } from "../models/Keep.js";
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";
import LargeModal from "./LargeModal.vue";


export default {
  props: {
    keep: {
      type: Keep,
      required: true
    }
  },
  setup() {
    return {
      async setActiveKeep(keepId) {
        try {
          await keepsService.setActiveKeep(keepId);
        }
        catch (error) {
          Pop.error(error);
        }
      }
    };
  },
  components: { LargeModal, LargeModal }
}
</script>


<style lang="scss" scoped>
// img {
//   width: 18vw;
//   object-fit: contain;
//   border-radius: 8px;
// }

.card-image {
  width: 16vw;
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