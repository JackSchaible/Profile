// FontAwesome configuration
import { config, library } from "@fortawesome/fontawesome-svg-core";
import { faLinkedin, faGithub } from "@fortawesome/free-brands-svg-icons";
import {
  faFileText,
  faExternalLinkAlt,
  faSun,
  faMoon,
  faArrowLeft,
  faHammer,
  faPen,
  faEnvelope,
} from "@fortawesome/free-solid-svg-icons";

// Prevent FontAwesome from adding its CSS since we're using Tailwind
config.autoAddCss = false;

// Add icons to the library
library.add(
  faLinkedin,
  faGithub,
  faFileText,
  faExternalLinkAlt,
  faSun,
  faMoon,
  faArrowLeft,
  faHammer,
  faPen,
  faEnvelope
);
