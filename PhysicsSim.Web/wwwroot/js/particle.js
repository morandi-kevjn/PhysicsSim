window.particleSim = {
    drawParticle: function (canvasId, particleList) {
        const canvas = document.getElementById(canvasId);
        if (!canvas) return;

        const ctx = canvas.getContext('2d');
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        particleList.forEach(particle => {
            ctx.beginPath();
            ctx.arc(particle.x, canvas.height - particle.y, 5, 0, 2 * Math.PI);
            ctx.fillStyle = "blue";
            ctx.fill();
        });
    }
}