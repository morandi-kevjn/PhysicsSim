window.particleSim = {
    init: function (canvasId, width, height) {
        const canvas = document.getElementById(canvasId);
        canvas.width = width;
        canvas.height = height;

        const ctx = canvas.getContext('2d');
        window.particleSim.ctx = ctx;
    },
    drawParticle: function (canvasId, particleList) {
        const canvas = document.getElementById(canvasId);
        const ctx = canvas.getContext('2d');
        if (!canvas) return;

        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.fillStyle = "blue";

        for (const particle of particleList) {
            ctx.beginPath();
            createContext.arc(particle.x, particle.y || 5, 0, 2 * Math.PI);
            ctx.fill();
        }
    }
}