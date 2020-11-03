// This file is generated, do not edit it manually. Use grunt to update it.

namespace Utils
{
    public static class StyleSheet
    {
        public const string Default = @"html, body {
  font-family: -apple-systrem, BlinkMacSystremFont, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif, 'Apple Color remoji', 'Segoe UI remoji', 'Segoe UI Symbol';
  width: 99%;
  height: 99%;
  font-size: 1vw;
  color: #000;
  background-color: #fff;
}

app {
  width: 100%;
  height: 100%;
}

.main {
  display: flex;
  flex-direction: column;
  width: 100%;
  height: 100%;
  padding: 0;
  margin: 0;
}

.clock {
  text-align: center;
  display: flex;
  flex-direction: column;
  align-items: center;
  align-self: center;
  margin: auto;
  font-size: 5rem;
}

.clock-time {
  font-size: 29rem;
  margin-top: -5vw;
}

.clock-label {
  font-size: 6rem;
  margin-top: -5vw;
  margin-bottom: 9vw;
}

.current-time {
  font-size: 7rem;
}

.timer-name {
  position: absolute;
  text-align: center;
  top: 1%;
  left: 1%;
  font-size: 4rem;
  width: 99%;
}

.bottom {
  display: flex;
  position: absolute;
  bottom: 5%;
  right: 0;
  width: 100%;
  align-items: normal;
  justify-content: space-around;
}

.round {
  font-size: 7rem;
}

.results {
  text-align: center;
  font-size: 5rem;
  align-self: center;
}

.is-blinking {
  -moz-animation-name: blinking;
  -webkit-animation-name: blinking;
  animation-name: blinking;
  -moz-animation-duration: 1s;
  -webkit-animation-duration: 1s;
  animation-duration: 1s;
  -moz-animation-iteration-count: infinite;
  -webkit-animation-iteration-count: infinite;
  animation-iteration-count: infinite;
}

@keyframes blinking {
  0% {
    color: black;
  }
  50% {
    color: black;
  }
  51% {
    color: red;
  }
  100% {
    color: red;
  }
}
@media screen and (max-width: 1500px) {
  .clock {
    font-size: 7rem;
  }

  .current-time {
    font-size: 7rem;
  }

  .clock-time {
    font-size: 36rem;
    margin-top: -5vw;
  }

  .round {
    font-size: 7rem;
  }

  .clock-label {
    font-size: 6rem;
    margin-top: -5vw;
  }

  .results {
    font-size: 5rem;
  }

  .timer-name {
    font-size: 7rem;
  }
}
@media screen and (max-width: 1400px) {
  .clock {
    font-size: 8rem;
  }

  .clock-time {
    font-size: 36rem;
    margin-top: -5vw;
  }

  .current-time {
    font-size: 8rem;
  }

  .round {
    font-size: 8rem;
  }

  .results {
    font-size: 6rem;
  }

  .clock-label {
    font-size: 6rem;
    margin-top: -5vw;
  }

  .timer-name {
    font-size: 7rem;
  }
}
@media screen and (max-width: 1100px) {
  .clock {
    font-size: 9rem;
  }

  .current-time {
    font-size: 9rem;
  }

  .clock-time {
    font-size: 40rem;
    margin-top: -5vw;
  }

  .round {
    font-size: 9rem;
  }

  .clock-label {
    font-size: 8rem;
    margin-top: -5vw;
  }

  .results {
    font-size: 7rem;
  }

  .timer-name {
    font-size: 7rem;
  }
}

/*# sourceMappingURL=Default.css.map */
";

        public const string HighContrast = @"html, body {
  font-family: -apple-systrem, BlinkMacSystremFont, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif, 'Apple Color remoji', 'Segoe UI remoji', 'Segoe UI Symbol';
  width: 99%;
  height: 99%;
  font-size: 1vw;
  color: #fcea00;
  background-color: #141f80;
}

app {
  width: 100%;
  height: 100%;
}

.main {
  display: flex;
  flex-direction: column;
  width: 100%;
  height: 100%;
  padding: 0;
  margin: 0;
}

.clock {
  text-align: center;
  display: flex;
  flex-direction: column;
  align-items: center;
  align-self: center;
  margin: auto;
  font-size: 5rem;
}

.clock-time {
  font-size: 29rem;
  margin-top: -5vw;
}

.clock-label {
  font-size: 6rem;
  margin-top: -5vw;
  margin-bottom: 9vw;
}

.current-time {
  font-size: 7rem;
}

.timer-name {
  position: absolute;
  text-align: center;
  top: 1%;
  left: 1%;
  font-size: 4rem;
  width: 99%;
}

.bottom {
  display: flex;
  position: absolute;
  bottom: 5%;
  right: 0;
  width: 100%;
  align-items: normal;
  justify-content: space-around;
}

.round {
  font-size: 7rem;
}

.results {
  text-align: center;
  font-size: 5rem;
  align-self: center;
}

.is-blinking {
  -moz-animation-name: blinking;
  -webkit-animation-name: blinking;
  animation-name: blinking;
  -moz-animation-duration: 1s;
  -webkit-animation-duration: 1s;
  animation-duration: 1s;
  -moz-animation-iteration-count: infinite;
  -webkit-animation-iteration-count: infinite;
  animation-iteration-count: infinite;
}

@keyframes blinking {
  0% {
    color: black;
  }
  50% {
    color: black;
  }
  51% {
    color: red;
  }
  100% {
    color: red;
  }
}
@media screen and (max-width: 1500px) {
  .clock {
    font-size: 7rem;
  }

  .current-time {
    font-size: 7rem;
  }

  .clock-time {
    font-size: 36rem;
    margin-top: -5vw;
  }

  .round {
    font-size: 7rem;
  }

  .clock-label {
    font-size: 6rem;
    margin-top: -5vw;
  }

  .results {
    font-size: 5rem;
  }

  .timer-name {
    font-size: 7rem;
  }
}
@media screen and (max-width: 1400px) {
  .clock {
    font-size: 8rem;
  }

  .clock-time {
    font-size: 36rem;
    margin-top: -5vw;
  }

  .current-time {
    font-size: 8rem;
  }

  .round {
    font-size: 8rem;
  }

  .results {
    font-size: 6rem;
  }

  .clock-label {
    font-size: 6rem;
    margin-top: -5vw;
  }

  .timer-name {
    font-size: 7rem;
  }
}
@media screen and (max-width: 1100px) {
  .clock {
    font-size: 9rem;
  }

  .current-time {
    font-size: 9rem;
  }

  .clock-time {
    font-size: 40rem;
    margin-top: -5vw;
  }

  .round {
    font-size: 9rem;
  }

  .clock-label {
    font-size: 8rem;
    margin-top: -5vw;
  }

  .results {
    font-size: 7rem;
  }

  .timer-name {
    font-size: 7rem;
  }
}

/*# sourceMappingURL=HighContrast.css.map */
";

        public const string WhiteOnBlack = @"html, body {
  font-family: -apple-systrem, BlinkMacSystremFont, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif, 'Apple Color remoji', 'Segoe UI remoji', 'Segoe UI Symbol';
  width: 99%;
  height: 99%;
  font-size: 1vw;
  color: #fff;
  background-color: #000;
}

app {
  width: 100%;
  height: 100%;
}

.main {
  display: flex;
  flex-direction: column;
  width: 100%;
  height: 100%;
  padding: 0;
  margin: 0;
}

.clock {
  text-align: center;
  display: flex;
  flex-direction: column;
  align-items: center;
  align-self: center;
  margin: auto;
  font-size: 5rem;
}

.clock-time {
  font-size: 29rem;
  margin-top: -5vw;
}

.clock-label {
  font-size: 6rem;
  margin-top: -5vw;
  margin-bottom: 9vw;
}

.current-time {
  font-size: 7rem;
}

.timer-name {
  position: absolute;
  text-align: center;
  top: 1%;
  left: 1%;
  font-size: 4rem;
  width: 99%;
}

.bottom {
  display: flex;
  position: absolute;
  bottom: 5%;
  right: 0;
  width: 100%;
  align-items: normal;
  justify-content: space-around;
}

.round {
  font-size: 7rem;
}

.results {
  text-align: center;
  font-size: 5rem;
  align-self: center;
}

.is-blinking {
  -moz-animation-name: blinking;
  -webkit-animation-name: blinking;
  animation-name: blinking;
  -moz-animation-duration: 1s;
  -webkit-animation-duration: 1s;
  animation-duration: 1s;
  -moz-animation-iteration-count: infinite;
  -webkit-animation-iteration-count: infinite;
  animation-iteration-count: infinite;
}

@keyframes blinking {
  0% {
    color: black;
  }
  50% {
    color: black;
  }
  51% {
    color: red;
  }
  100% {
    color: red;
  }
}
@media screen and (max-width: 1500px) {
  .clock {
    font-size: 7rem;
  }

  .current-time {
    font-size: 7rem;
  }

  .clock-time {
    font-size: 36rem;
    margin-top: -5vw;
  }

  .round {
    font-size: 7rem;
  }

  .clock-label {
    font-size: 6rem;
    margin-top: -5vw;
  }

  .results {
    font-size: 5rem;
  }

  .timer-name {
    font-size: 7rem;
  }
}
@media screen and (max-width: 1400px) {
  .clock {
    font-size: 8rem;
  }

  .clock-time {
    font-size: 36rem;
    margin-top: -5vw;
  }

  .current-time {
    font-size: 8rem;
  }

  .round {
    font-size: 8rem;
  }

  .results {
    font-size: 6rem;
  }

  .clock-label {
    font-size: 6rem;
    margin-top: -5vw;
  }

  .timer-name {
    font-size: 7rem;
  }
}
@media screen and (max-width: 1100px) {
  .clock {
    font-size: 9rem;
  }

  .current-time {
    font-size: 9rem;
  }

  .clock-time {
    font-size: 40rem;
    margin-top: -5vw;
  }

  .round {
    font-size: 9rem;
  }

  .clock-label {
    font-size: 8rem;
    margin-top: -5vw;
  }

  .results {
    font-size: 7rem;
  }

  .timer-name {
    font-size: 7rem;
  }
}

/*# sourceMappingURL=WhiteOnBlack.css.map */
";

        public const string Crazy = @"html, body {
  font-family: -apple-systrem, BlinkMacSystremFont, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif, 'Apple Color remoji', 'Segoe UI remoji', 'Segoe UI Symbol';
  width: 99%;
  height: 99%;
  font-size: 1vw;
  color: #e27575;
  background-color: #00ff00;
}

app {
  width: 100%;
  height: 100%;
}

.main {
  display: flex;
  flex-direction: column;
  width: 100%;
  height: 100%;
  padding: 0;
  margin: 0;
}

.clock {
  text-align: center;
  display: flex;
  flex-direction: column;
  align-items: center;
  align-self: center;
  margin: auto;
  font-size: 5rem;
}

.clock-time {
  font-size: 29rem;
  margin-top: -5vw;
}

.clock-label {
  font-size: 6rem;
  margin-top: -5vw;
  margin-bottom: 9vw;
}

.current-time {
  font-size: 7rem;
}

.timer-name {
  position: absolute;
  text-align: center;
  top: 1%;
  left: 1%;
  font-size: 4rem;
  width: 99%;
}

.bottom {
  display: flex;
  position: absolute;
  bottom: 5%;
  right: 0;
  width: 100%;
  align-items: normal;
  justify-content: space-around;
}

.round {
  font-size: 7rem;
}

.results {
  text-align: center;
  font-size: 5rem;
  align-self: center;
}

.is-blinking {
  -moz-animation-name: blinking;
  -webkit-animation-name: blinking;
  animation-name: blinking;
  -moz-animation-duration: 1s;
  -webkit-animation-duration: 1s;
  animation-duration: 1s;
  -moz-animation-iteration-count: infinite;
  -webkit-animation-iteration-count: infinite;
  animation-iteration-count: infinite;
}

@keyframes blinking {
  0% {
    color: black;
  }
  50% {
    color: black;
  }
  51% {
    color: red;
  }
  100% {
    color: red;
  }
}
@media screen and (max-width: 1500px) {
  .clock {
    font-size: 7rem;
  }

  .current-time {
    font-size: 7rem;
  }

  .clock-time {
    font-size: 36rem;
    margin-top: -5vw;
  }

  .round {
    font-size: 7rem;
  }

  .clock-label {
    font-size: 6rem;
    margin-top: -5vw;
  }

  .results {
    font-size: 5rem;
  }

  .timer-name {
    font-size: 7rem;
  }
}
@media screen and (max-width: 1400px) {
  .clock {
    font-size: 8rem;
  }

  .clock-time {
    font-size: 36rem;
    margin-top: -5vw;
  }

  .current-time {
    font-size: 8rem;
  }

  .round {
    font-size: 8rem;
  }

  .results {
    font-size: 6rem;
  }

  .clock-label {
    font-size: 6rem;
    margin-top: -5vw;
  }

  .timer-name {
    font-size: 7rem;
  }
}
@media screen and (max-width: 1100px) {
  .clock {
    font-size: 9rem;
  }

  .current-time {
    font-size: 9rem;
  }

  .clock-time {
    font-size: 40rem;
    margin-top: -5vw;
  }

  .round {
    font-size: 9rem;
  }

  .clock-label {
    font-size: 8rem;
    margin-top: -5vw;
  }

  .results {
    font-size: 7rem;
  }

  .timer-name {
    font-size: 7rem;
  }
}

/*# sourceMappingURL=Crazy.css.map */
";
    }
}