[System.Serializable]
struct EnemyPriority{

    public int priority;
    public float probMin;
    public float probMax;

        public EnemyPriority(int priority, float probMin, float probMax) {
        this.priority = priority;
        this.probMin = probMin;
        this.probMax = probMax;
    }

}

